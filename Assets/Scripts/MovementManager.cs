using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
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
      if (Input.GetKeyDown (KeyCode.Space)) 
      {
         if(ascript.enabled == true)
         {
           ascript.enabled = false;
           bscript.enabled = true;
         }
         else
         {
           ascript.enabled = true;
           bscript.enabled = false;
         }
      }
  }
}
