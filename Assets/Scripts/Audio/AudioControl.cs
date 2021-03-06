﻿using UnityEngine;
using System.Runtime.InteropServices;

public class AudioControl : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void SetVariables();
    
    [DllImport("__Internal")]
    private static extern void PlayAudio();

    [DllImport("__Internal")]
    private static extern void StopAudio();

    [DllImport("__Internal")]
    private static extern void ToFrequency();

    [DllImport("__Internal")]
    private static extern void SetPitch();

    [DllImport("__Internal")]
    private static extern void StepCount();

    [DllImport("__Internal")]
    private static extern void PlayKick();

    [DllImport("__Internal")]
    private static extern void DistortionCurve();

    [DllImport("__Internal")]
    private static extern void ValueLimit();

    void Start()
    {
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

    public void StopMusic()
    {   
        #if UNITY_WEBGL && !UNITY_EDITOR
        StopAudio();
        #endif
    }

}