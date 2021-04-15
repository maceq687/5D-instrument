using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncronizationPurple : MonoBehaviour
{
    void Update()
    {
        PhotonNetwork.automaticallySyncScene = true;
    }
}
