using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.UtilityScripts;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject Button;
    public GameObject Instructions;
    public GameObject SceneCamera;
    //public PhotonView photonView;
    Vector3[] list1 = new Vector3[5] {new Vector3(0, 0, 0), new Vector3( 185, 0, 130), new Vector3( -185, 0, 130), new Vector3( 116, 0, 355), new Vector3( -116, 0, 355)};
    Quaternion[] list2 = new Quaternion[5] {(Quaternion.identity), Quaternion.Euler(0, -73, 0), Quaternion.Euler(0, 73, 0), Quaternion.Euler(0, -144, 0), Quaternion.Euler(0, 144, 0)};

    void Awake()
    {
        Button.SetActive(true);
        PhotonNetwork.automaticallySyncScene = true; 
        //photonView = GetComponent<PhotonView>();
    }

    public void SpawnPlayer()
    {   
        Debug.Log("Number of players: " + PhotonNetwork.countOfPlayers);
        int seatNumber = PhotonNetwork.player.GetRoomIndex();
        PhotonNetwork.Instantiate(PlayerPrefab.name, list1[seatNumber], list2[seatNumber], 0);
        Button.SetActive(false);
        SpawnInstructions();
        SceneCamera.SetActive(false);
        Debug.Log("Seat index: " + seatNumber);
    }

    void SpawnInstructions()
    {
        Instructions.SetActive(true);
        StartCoroutine(ExampleCoroutine());
        Instructions.SetActive(false);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
    }

    // void OnPhotonPlayerDisconnected(PhotonPlayer newPlayer)
    // {
    //     PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
    //     PhotonNetwork.LeaveRoom();
    // }
}
 