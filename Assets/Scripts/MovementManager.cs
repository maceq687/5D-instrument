using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
  public FollowMouse ascript;
  //public FollowMouseBlue bscript;
  public FollowCV bscript;

  //public GameObject GameManager;
  //private GameManager bool_script;
  
  void Start () {
      ascript = GetComponent<FollowMouse> ();
      //bscript = GetComponent<FollowMouseBlue> ();
      bscript = GetComponent<FollowCV> ();
      ascript.enabled = false;
      bscript.enabled = true;

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
