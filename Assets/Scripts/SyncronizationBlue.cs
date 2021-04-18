using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncronizationBlue : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        PhotonNetwork.automaticallySyncScene = true;
    }
}
