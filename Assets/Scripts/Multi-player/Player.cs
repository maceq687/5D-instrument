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
    int seatNumber;
    public PhotonView photonView;
    public PhotonView photonViewBot;
    public GameObject PlayerCamera;
    String[] BotList = new String[5] {"BotBlue", "BotPurple", "BotPink", "BotGreen", "BotOrange"};

    private void Awake()
    {
        if(photonView.isMine)
        {
            PlayerCamera.SetActive(true);
        }
    }

    void Start()
    {
        seatNumber = PhotonNetwork.player.GetRoomIndex();
        // Bot = GameObject.Find(BotList[seatNumber]);
        if (photonView.isMine)
        {
            // this.gameObject.GetComponent<PhotonView>().name = "Player" + seatNumber.ToString();
            Bot = GameObject.Find(BotList[seatNumber]);
            // Bot.name = Bot.name.Replace("Bot", BotList[seatNumber]);
        }
        else
        {
            int playerSeat = photonView.owner.GetRoomIndex();
            this.gameObject.name = "Player" + playerSeat.ToString();
            Debug.Log("Say hello to Player" + playerSeat.ToString());
            Bot = GameObject.Find("Player" + playerSeat.ToString() + "/Bot");
            Bot.name = Bot.name.Replace("Bot", BotList[playerSeat]);
        }
        photonViewBot = Bot.GetComponent<PhotonView>();
    }

    void Update()
    {
        if(photonViewBot.isMine)
        {
            // Debug.Log(FollowMouse);
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
