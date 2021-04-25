using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.UtilityScripts;
using System;

public class Player : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public GameObject PlayerCamera;

    // public double x;
    // public double y;

    public bool FollowMouse;

    public GameObject Bot;

    private void Awake()
    {
        
        GameObject[] BotList = new GameObject[5] {GameObject.Find("BotBlue"), GameObject.Find("BotPurple"), GameObject.Find("BotPink"), GameObject.Find("BotGreen"), GameObject.Find("BotOrange")};

        int seatNumber = PhotonNetwork.player.GetRoomIndex();
        //Debug.Log(seatNumber);

        if(photonView.isMine)
        {
            PlayerCamera.SetActive(true);
        }

        Bot = BotList[seatNumber];
        //Debug.Log(Bot);
    } 

    private void Update()
    {
        if(photonView.isMine)
        {
            if (Input.GetKeyDown (KeyCode.Space))
            {
                FollowMouse = !FollowMouse;
            }

            if (FollowMouse == true)
            {
                CheckInputFollowMouse();
            }
            else
            {
                Move();
            }
            
        }
    }

    private void CheckInputFollowMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 102;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        Bot.transform.position = Vector3.MoveTowards(Bot.transform.position, worldPosition, 10);
    }

    public void Move()
    {
        Debug.Log("Running Computer Vision");
        // Coordinates cord = JsonUtility.FromJson<Coordinates>(args);
        // double x = (double)cord.xHand;
        // double y = (double)cord.yHand;
        // x = (x - 0.5) * 84;
        // y = (-y + 0.5) * 84;
        // float xFloat = (float)x;
        // float yFloat = (float)y;
        // Bot.transform.localPosition = new Vector3(xFloat, yFloat, 0);
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

// [Serializable]
// public class Coordinates
// {
//     public double xHand;
//     public double yHand;
// }

