using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject Logo;
    void Start()
    {
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {        
        // Wait for 3 secs.
        yield return new WaitForSeconds(3);
 
        // Application.LoadLevel("MainMenu");
        SceneManager.LoadScene(1);
    }
}
