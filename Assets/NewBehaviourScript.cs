using UnityEngine;
using System.Runtime.InteropServices;

public class NewBehaviourScript : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void SetVar();
    
    [DllImport("__Internal")]
    private static extern void Init();
    
    [DllImport("__Internal")]
    private static extern void Play();

    void Start() {
        SetVar();
        Init();
    }

    void OnMouseDown() {
        Debug.Log("clicked");
        Play();
    }
}
