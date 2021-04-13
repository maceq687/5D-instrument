using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject Button;
    public GameObject SceneCamera;

    // public bool PlayerPosOne = true;
    // public bool PlayerPosTwo = true;
    // public bool PlayerPosThree = true;
    // public bool PlayerPosFour = true;
    // public bool PlayerPosFive = true;      

    private void Awake()
    {
        
        Button.SetActive(true);
    }

    public void SpawnPlayer()
    {
        PhotonNetwork.automaticallySyncScene = true;

        //PlayerPosOne == true

        if (PhotonNetwork.countOfPlayers == 1)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(0, 0), Quaternion.identity, 0);
            //PlayerPosOne = false;
            Button.SetActive(false);
            SceneCamera.SetActive(false);
        }

        // PlayerPosOne == false && PlayerPosTwo == true
        else if (PhotonNetwork.countOfPlayers == 2)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3( 185, 0, 130), Quaternion.Euler(0, -73, 0), 0);
            Button.SetActive(false);
            //PlayerPosTwo = false;
            SceneCamera.SetActive(false);
        }

        //PlayerPosTwo == false && PlayerPosThree == true
        else if (PhotonNetwork.countOfPlayers == 3)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3( -185, 0, 130), Quaternion.Euler(0, 73, 0), 0);
            //PlayerPosThree = false;
            Button.SetActive(false);
            //SceneCamera.SetActive(false);
        }

        //PlayerPosThree == false && PlayerPosFour == true
        else if (PhotonNetwork.countOfPlayers == 4)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3( 116, 0, 355), Quaternion.Euler(0, 37, 0), 0);
           // PlayerPosFour = false;
            Button.SetActive(false);
            //SceneCamera.SetActive(false);
        }

        else {
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3( -116, 0, 355), Quaternion.Euler(0, -37, 0), 0);
            //PlayerPosFive = false;
            Button.SetActive(false);
            //SceneCamera.SetActive(false);
        }
    }
}
 