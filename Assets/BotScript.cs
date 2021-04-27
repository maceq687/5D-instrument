using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.UtilityScripts;
using System;
using System.Runtime.InteropServices;

public class BotScript : Photon.MonoBehaviour
{
    // [DllImport("__Internal")]
    // private static extern void ControlVideoStream(string name);
    // public Camera UserCamera;
    // bool FollowMouse = true;
    // private PhotonView photonView;
    // private GameObject Bot;
    // private Vector3 mouseToCameraPosition;
    // private Vector3 mouseToWorldPosition;
    // private Vector3 handPosition;
    // int seatNumber;
    void Start()
    {
        // photonView = GetComponent<PhotonView>();
        // seatNumber = PhotonNetwork.player.GetRoomIndex();
        // ++seatNumber;
        // if(photonView.isMine)
        // {
        //     // String[] BotList = new String[5] {"BotBlue", "BotPurple", "BotPink", "BotGreen", "BotOrange"};
        //     // Bot = GameObject.Find("Player" + seatNumber.ToString() + "/Bot");
        //     // Bot.transform.name = transform.name.Replace("Bot", BotList[seatNumber]);
        // }
    }

    // void Update()
    // {
    //     if(photonView.isMine)
    //     {
    //         // Debug.Log(FollowMouse);
    //         if (Input.GetKeyDown (KeyCode.Space))
    //         {
    //             FollowMouse = !FollowMouse;
    //             String[] BotList = new String[5] {"BotBlue", "BotPurple", "BotPink", "BotGreen", "BotOrange"};
    //             // triggering this will send object name and toggle the computer vision on after first space press
    //             #if UNITY_WEBGL && !UNITY_EDITOR
    //             ControlVideoStream(BotList[seatNumber]);
    //             #endif
    //         }

    //         if (FollowMouse == true)
    //         {   
    //             MouseControl();
    //             transform.position = mouseToWorldPosition;
    //         }
    //         else
    //         {   
    //             // string test = "{\"xHand\":1,\"yHand\":0}"; // moves dot to top right corner
    //             // Debug.Log(test);
    //             // CVControl(test);
    //             transform.position = handPosition;
    //         }
    //         Debug.Log(transform.localPosition);
    //     }
    // }
    // private void MouseControl()
    // {
    //     Vector3 mousePos = Input.mousePosition;
    //     mousePos.z = 102;
    //     mouseToWorldPosition = UserCamera.ScreenToWorldPoint(mousePos);
    //     mouseToCameraPosition = transform.InverseTransformPoint(mouseToWorldPosition);
    //     mouseToCameraPosition.x = Mathf.Clamp(mouseToCameraPosition.x, -42, 42);
    //     mouseToCameraPosition.y = Mathf.Clamp(mouseToCameraPosition.y, -42, 42);
        
    // }

    // public void CVControl(string args)
    // {
    //     // Debug.Log("Running Computer Vision");
    //     Coordinates cord = JsonUtility.FromJson<Coordinates>(args);
    //     double x = (double)cord.xHand;
    //     double y = (double)cord.yHand;
    //     x = (x - 0.5) * 84;
    //     y = (-y + 0.5) * 84;
    //     float xFloat = (float)x;
    //     float yFloat = (float)y;
    //     handPosition = new Vector3(xFloat, yFloat, 0);
    // }

}

// [Serializable]
// public class Coordinates
// {
//     public double xHand;
//     public double yHand;
// }
