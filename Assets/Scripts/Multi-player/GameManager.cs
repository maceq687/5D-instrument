using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject Button;
    public GameObject SceneCamera;
    // public PhotonView photonView;

    // public bool SeatOneOccupation;
    // public bool SeatTwoOccupation;
    // public bool SeatThreeOccupation;
    // public bool SeatFourOccupation;
    // public bool SeatFiveOccupation;


    Vector3[] list1 = new Vector3[5] {new Vector3(0, 0, 0), new Vector3( 185, 0, 130), new Vector3( -185, 0, 130), new Vector3( 116, 0, 355), new Vector3( -116, 0, 355)};
    Quaternion[] list2 = new Quaternion[5] {(Quaternion.identity), Quaternion.Euler(0, -73, 0), Quaternion.Euler(0, 73, 0), Quaternion.Euler(0, -144, 0), Quaternion.Euler(0, 144, 0)};

    private void Awake()
    {
        Button.SetActive(true);
        //PhotonNetwork.automaticallySyncScene = true; 
        //photonView = GetComponent<PhotonView>();
    }

    public void SpawnPlayer()
    {
        if (PhotonNetwork.countOfPlayers == 1)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, list1[0], list2[0], 0);

            // SeatOneOccupation = true;
            // Debug.Log("SeatPilot");

            Button.SetActive(false);
            SceneCamera.SetActive(false);
        }

        else if (PhotonNetwork.countOfPlayers == 2)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, list1[1], list2[1], 0);
                    
            // SeatTwoOccupation = true;
            // Debug.Log("Seat2");

            Button.SetActive(false);
            SceneCamera.SetActive(false);
        }

        else if (PhotonNetwork.countOfPlayers == 3)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, list1[2], list2[2], 0);
                    
            // SeatThreeOccupation = true;
            // Debug.Log("Seat3");

            Button.SetActive(false);
            SceneCamera.SetActive(false);
        }

        else if (PhotonNetwork.countOfPlayers == 4)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, list1[3], list2[3], 0);
                    
            // SeatFourOccupation = true;
            // Debug.Log("Seat4");

            Button.SetActive(false);
            SceneCamera.SetActive(false);
        }

        else 
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, list1[4], list2[4], 0);

            // Debug.Log("Seat5");

            Button.SetActive(false);
            SceneCamera.SetActive(false);
        }
        
    }
}
 