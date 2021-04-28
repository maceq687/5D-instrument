using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersioName = "0.1";
    [SerializeField] private GameObject ConnectPanel;
    public GameObject Button;
    public GameObject Message;
    private bool ApprovePlayerIn = false;

    
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersioName);
    }

    private void Update()
    {
        if (ApprovePlayerIn==true)
        {
            if (PhotonNetwork.countOfPlayers<6)
            {
                Message.SetActive(false);
                Button.SetActive(true);
                if (Input.GetKeyDown("return")) 
                {
                    JoinGame();
                }
            }
            else
            {
                Message.SetActive(true);
            }
        }
    } 

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
        ApprovePlayerIn = true;
    }

    public void CreateGame()
    {
        PhotonNetwork.CreateRoom("basic", new RoomOptions() { MaxPlayers = 5, PublishUserId = true}, null);
    }


    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;
        roomOptions.PublishUserId = true;
        PhotonNetwork.JoinOrCreateRoom("basic", roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("trial");
        Debug.Log("Joined room");
    }

}
