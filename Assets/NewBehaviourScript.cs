using UnityEngine;
using System.Runtime.InteropServices;

public class NewBehaviourScript : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void SetVariables();
    
    [DllImport("__Internal")]
    private static extern void PlayAudio();

    [DllImport("__Internal")]
    private static extern void ToFrequency();

    [DllImport("__Internal")]
    private static extern void SetPitch();

    [DllImport("__Internal")]
    private static extern void StepCount();

    [DllImport("__Internal")]
    private static extern void PlayKick();

    void Start() {
        #if UNITY_WEBGL && !UNITY_EDITOR
        SetVariables();
        #endif
    }

    public void PlayMusic()
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
        PlayAudio();
        #endif
        
    }
}