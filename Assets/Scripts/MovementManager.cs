using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
  public DotMovement ascript;
  public FollowMouse bscript;
  
  void Start () {
      ascript = GetComponent<DotMovement> ();
      bscript = GetComponent<FollowMouse> ();
      ascript.enabled = true;
      bscript.enabled = false;
  }
  void Update () 
  {
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
