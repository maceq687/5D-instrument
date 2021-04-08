using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject Button;
    public GameObject SceneCamera;

    public bool PlayerPosOne = true;


    private void Awake()
    {
        Button.SetActive(true);
    }

    public void SpawnPlayer()
    {
        if (PlayerPosOne == true)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(0, 0), Quaternion.identity, 0);
            PlayerPosOne = false;
            Button.SetActive(false);
            //SceneCamera.SetActive(false);
        }
        else if (PlayerPosOne == false){
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3( 185, 0, 130), Quaternion.Euler(0, -73, 0), 0);
            Button.SetActive(false);
            //SceneCamera.SetActive(false);
        }
    }
}
 