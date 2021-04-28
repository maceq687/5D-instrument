using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.UtilityScripts;
using System;
using System.Runtime.InteropServices;

public class Player : Photon.MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ControlVideoStream(string name);
    public Camera UserCamera;
    bool FollowMouse = true;
    private GameObject Bot;
    private Vector3 mouseToCameraPosition;
    private Vector3 mouseToWorldPosition;
    private Vector3 handPosition;
    private PhotonView photonView;
    private PhotonView photonViewBot;
    public GameObject PlayerCamera;
    SpriteRenderer sprite;
    String[] BotList = new String[5] {"BotBlue", "BotPurple", "BotPink", "BotGreen", "BotOrange"};
    Color[] colors = new Color[5] { new Color(0,1,1,1), new Color(1,0,1,1), new Color(1,0,0,1), new Color(0,1,0,1),  new Color(1,1,0,1)};
    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
        if(photonView.isMine)
        {
            PlayerCamera.SetActive(true);
        }
    }

    void Start()
    {
        if (photonView.isMine)
        {
            // renaming player and bot prefabs that belong to the player
            int seatNumber = PhotonNetwork.player.GetRoomIndex();
            this.gameObject.name = "Player" + seatNumber.ToString();
            Bot = GameObject.Find("Player" + seatNumber.ToString() + "/Bot");
            Bot.name = Bot.name.Replace("Bot", BotList[seatNumber]);
            sprite = Bot.GetComponent<SpriteRenderer>();
            sprite.color = colors[seatNumber];
        }
        else
        {
            // renaming player and bot prefabs that belong to other players in the room
            int playerSeat = photonView.owner.GetRoomIndex();
            this.gameObject.name = "Player" + playerSeat.ToString();
            Debug.Log("Say hello to Player" + playerSeat.ToString());
            Bot = GameObject.Find("Player" + playerSeat.ToString() + "/Bot");
            Bot.name = Bot.name.Replace("Bot", BotList[playerSeat]);
            sprite = Bot.GetComponent<SpriteRenderer>();
            sprite.color = colors[playerSeat];
        }
        photonViewBot = Bot.GetComponent<PhotonView>();
    }

    void Update()
    {
        if(photonViewBot.isMine)
        {
            if (Input.GetKeyDown (KeyCode.Space))
            {
                FollowMouse = !FollowMouse;
                // triggering this will send object name and toggle the computer vision on after first space press
                #if UNITY_WEBGL && !UNITY_EDITOR
                ControlVideoStream(this.gameObject.name);
                #endif
            }

            if (FollowMouse == true)
            {   
                MouseControl();
                Bot.transform.localPosition = mouseToCameraPosition;
            }
            else
            {   
                // string test = "{\"xHand\":1,\"yHand\":0}"; // moves dot to top right corner
                // Debug.Log(test);
                // CVControl(test);
                Bot.transform.localPosition = handPosition;
            }
            // Debug.Log(Bot.transform.localPosition);
        }
    }

    private void MouseControl()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 102;
        mouseToWorldPosition = UserCamera.ScreenToWorldPoint(mousePos);
        mouseToCameraPosition = transform.InverseTransformPoint(mouseToWorldPosition);
        mouseToCameraPosition.x = Mathf.Clamp(mouseToCameraPosition.x, -42, 42);
        mouseToCameraPosition.y = Mathf.Clamp(mouseToCameraPosition.y, -42, 42);
        
    }

    public void CVControl(string args)
    {
        // Debug.Log("Running Computer Vision");
        Coordinates cord = JsonUtility.FromJson<Coordinates>(args);
        double x = (double)cord.xHand;
        double y = (double)cord.yHand;
        x = (x - 0.5) * 84;
        y = (-y + 0.5) * 84;
        float xFloat = (float)x;
        float yFloat = (float)y;
        handPosition = new Vector3(xFloat, yFloat, 0);
    }

}

[Serializable]
public class Coordinates
{
    public double xHand;
    public double yHand;
}
