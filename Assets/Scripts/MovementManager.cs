using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
  public DotMovement ascript;
  public FollowMouseBlue bscript;

  public GameObject GameManager;
  private GameManager bool_script;
  
  void Start () {
      ascript = GetComponent<DotMovement> ();
      bscript = GetComponent<FollowMouseBlue> ();
      ascript.enabled = true;
      bscript.enabled = false;

      bool_script = GameManager.GetComponent<PlayerPosOne>();


  }
  void Update () 
  {
      //Input.GetKeyDown (KeyCode.Space)
      if (bool_script.PlayerPosOne == false) 
      {
         if(ascript.enabled == true)
         {
           ascript.enabled = false;
           bscript.enabled = true;
        // }
        // else
        // {
        //   ascript.enabled = true;
        //   bscript.enabled = false;
         }
      }
  }
}
