using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManagerPurple : MonoBehaviour
{
  public SynchTest ascript;
  public FollowMouseBlue bscript;

  //public GameObject GameManager;
  //private GameManager bool_script;
  
  void Start () {
      ascript = GetComponent<SynchTest> ();
      bscript = GetComponent<FollowMouseBlue> ();
      ascript.enabled = true;
      bscript.enabled = false;

      //bool_script = GameManager.GetComponent<PlayerPosOne>();


  }
  void Update () 
  {
      //bool_script.PlayerPosOne == false
      //Input.GetKeyDown (KeyCode.A)
      if (PhotonNetwork.countOfPlayers == 2) 
      {
         if(ascript.enabled == true)
         {
           ascript.enabled = false;
           bscript.enabled = true;
         }
        //  else
        //  {
        //    ascript.enabled = true;
        //    bscript.enabled = false;
        //  }
      }
  }
}
