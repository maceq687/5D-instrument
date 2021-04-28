using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    public GameObject Logo;
    void Start()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {        
        //Wait for 14 secs.
        yield return new WaitForSeconds(3);
 
        //Turn My game object that is set to false(off) to True(on).
        Application.LoadLevel("MainMenu");
    }
}
