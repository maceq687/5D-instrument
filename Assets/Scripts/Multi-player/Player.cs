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
    public PhotonView photonView;
    public GameObject PlayerCamera;
    bool FollowMouse = true;
    public GameObject Bot;
    private Vector3 mouseToWorldPosition;
    private Vector3 handPosition;
    int seatNumber;

    private void Awake()
    {
        GameObject[] BotList = new GameObject[5] {GameObject.Find("BotBlue"), GameObject.Find("BotPurple"), GameObject.Find("BotPink"), GameObject.Find("BotGreen"), GameObject.Find("BotOrange")};
        seatNumber = PhotonNetwork.player.GetRoomIndex();
        //Debug.Log(seatNumber);
        if(photonView.isMine)
        {
            PlayerCamera.SetActive(true);
        }
        Bot = BotList[seatNumber];
        //Debug.Log(Bot);
    }

    void Start()
    {
        transform.name = transform.name.Replace("(Clone)", seatNumber.ToString()).Trim();
    }

    private void Update()
    {
        if(photonView.isMine)
        {
            // Debug.Log(FollowMouse);
            if (Input.GetKeyDown (KeyCode.Space))
            {
                FollowMouse = !FollowMouse;
                // triggering this will send object name and toggle the computer viosion on after first space press
                #if UNITY_WEBGL && !UNITY_EDITOR
                ControlVideoStream("Player" + seatNumber.ToString());
                #endif
            }

            if (FollowMouse == true)
            {   
                MouseControl();
                Bot.transform.position = Vector3.MoveTowards(Bot.transform.position, mouseToWorldPosition, 10);;
            }
            else
            {   
                // string test = "{\"xHand\":1,\"yHand\":0}";
                // Debug.Log(test);
                // CVControl(test);
                Bot.transform.position = Vector3.MoveTowards(Bot.transform.position, handPosition, 10);;
            }
            Debug.Log(Bot.transform.position);
        }
    }

    private void MouseControl()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 102;
        mouseToWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        mouseToWorldPosition.x = Mathf.Clamp(mouseToWorldPosition.x, -42, 42);
        mouseToWorldPosition.y = Mathf.Clamp(mouseToWorldPosition.y, -42, 42);
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
    // [PunRPC]
    // private void FlipTrue()
    // {
    //     sr.flipX=true;
    // }

    // [PunRPC]
    // private void FlipFalse()
    // {
    //     sr.flipX=false;
    // }
}

[Serializable]
public class Coordinates
{
    public double xHand;
    public double yHand;
}

