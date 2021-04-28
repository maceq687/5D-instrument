using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.UtilityScripts;
using System;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject PlayerPrefab;
    public GameObject Button;
    public GameObject SceneCamera;
    Vector3[] list1 = new Vector3[5] {new Vector3(0, 0, 0), new Vector3( 185, 0, 130), new Vector3( -185, 0, 130), new Vector3( 116, 0, 355), new Vector3( -116, 0, 355)};
    Quaternion[] list2 = new Quaternion[5] {(Quaternion.identity), Quaternion.Euler(0, -73, 0), Quaternion.Euler(0, 73, 0), Quaternion.Euler(0, -144, 0), Quaternion.Euler(0, 144, 0)};

    void Awake()
    {
        
        Button.SetActive(true);
        if (Input. GetKey ("return")) 
        {
            SpawnPlayer();
            //PlayMusic();
        }
        StartCoroutine(ActivationRoutine());
        PhotonNetwork.automaticallySyncScene = true; 
    }

    void Update()
    {
        if (Input. GetKey ("escape")) {
        //PhotonNetwork.LoadLevel("MainMenu");
        PhotonNetwork.LeaveRoom();
        Application.LoadLevel("MainMenu"); //not reconnecting to the lobby
        }
        if (Input. GetKey ("return")) {
        Instructions.SetActive(false);
        }
    }

    public void SpawnPlayer()
    {   
        Debug.Log("Number of players: " + PhotonNetwork.countOfPlayers);
        int seatNumber = PhotonNetwork.player.GetRoomIndex();
        PhotonNetwork.Instantiate(PlayerPrefab.name, list1[seatNumber], list2[seatNumber], 0);
        Button.SetActive(false);
        SceneCamera.SetActive(false);
        Debug.Log("I am Player" + seatNumber);
    }

    private IEnumerator ActivationRoutine()
     {        
         //Wait for 14 secs.
         yield return new WaitForSeconds(15);
 
         //Turn My game object that is set to false(off) to True(on).
         Instructions.SetActive(false);
 
     }
}
 