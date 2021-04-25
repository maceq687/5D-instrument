using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.UtilityScripts;

public class UIManager : MonoBehaviour
{
    public GameObject Instructions;

    void Start()
    { 
        
    }




    void StartInstructions()
    {
        Instructions = GameObject.Find("Instructions");

        Instructions.SetActive(true);

        StartCoroutine(ExampleCoroutine());

        Instructions.SetActive(false);
    }

        IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);
    }
}
