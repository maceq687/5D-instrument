using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class muteScript : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void StopAudio();

    void OnMouseDown() {
        // Debug.Log("clicked Sphere");
        #if UNITY_WEBGL && !UNITY_EDITOR
        StopAudio();
        #endif
    }
}
