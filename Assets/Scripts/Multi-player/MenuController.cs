using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersioName = "0.1";
    [SerializeField] private GameObject ConnectPanel;

    

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersioName);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
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
        // string userId = PhotonNetwork.AuthValues.UserId;
        // Debug.Log("userId: " + userId);
    }

    // public override void OnDisconnected(DisconnectedCause cause)
    // {
    //     Debug.Log("Disconnected for reason " + cause.ToSctring());
    // }

}
