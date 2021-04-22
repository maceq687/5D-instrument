using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject Button;
    public GameObject SceneCamera;

    public static Stack<Vector3> SeatsPosition = new Stack<Vector3>();
    public static Stack<Quaternion> SeatsRotation = new Stack<Quaternion>();

    private void Awake()
    {
        SeatsPosition.Push(new Vector3( -116, 0, 355)); //0
        SeatsPosition.Push(new Vector3( 116, 0, 355)); //1
        SeatsPosition.Push(new Vector3( -185, 0, 130)); //2
        SeatsPosition.Push(new Vector3( 185, 0, 130)); //3
        SeatsPosition.Push(new Vector3(0, 0, 0)); //4

        SeatsRotation.Push(Quaternion.Euler(0, 144, 0)); //0
        SeatsRotation.Push(Quaternion.Euler(0, -144, 0)); //1
        SeatsRotation.Push(Quaternion.Euler(0, 73, 0)); //2
        SeatsRotation.Push(Quaternion.Euler(0, -73, 0)); //3
        SeatsRotation.Push(Quaternion.identity); //4
        
        Button.SetActive(true);
    }
    public void SpawnPlayer()
    {
        PhotonNetwork.automaticallySyncScene = true;
        // Debug.Log( SeatsPosition.Peek());
        // Debug.Log( SeatsRotation.Peek());

        PhotonNetwork.Instantiate(PlayerPrefab.name, SeatsPosition.Peek(), SeatsRotation.Peek(), 0);

        string PlayerId = PhotonNetwork.AuthValues.UserId;
        //Debug.Log(PlayerId);

        SeatsPosition.Pop();
        SeatsRotation.Pop();

        Button.SetActive(false);
        SceneCamera.SetActive(false);

    }

    public void Update(){

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
            PhotonNetwork.LeaveRoom();
            //PhotonNetwork.LoadLevel(0);

            //SeatsPosition.Push();
            //SeatsRotation.Push();
        }
    }

    public void leaveRoom()
    {
     Debug.Log("IMOUTBITCHEZ");
    }
}
 