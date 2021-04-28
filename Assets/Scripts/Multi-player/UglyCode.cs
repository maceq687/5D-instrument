using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.UtilityScripts;
using System;
using System.Runtime.InteropServices;

public class UglyCode : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public GameObject Player;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            getdafname();
        }

    }
     public void getdafname()
    {
        Player.name = Player.GetComponent<PhotonView>().owner.name;
        Debug.Log (Player.name);
        this.photonView.RPC("getdafname_RPC", PhotonTargets.Others);
    }
    
  [PunRPC]
  private void getdafname_RPC()
  {
    Player.name = Player.GetComponent<PhotonView>().owner.name;
  }

}
