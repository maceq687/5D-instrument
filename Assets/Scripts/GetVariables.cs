using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class GetVariables : MonoBehaviour
{
    float xBlueOld;
    float yBlueOld;

    [DllImport("__Internal")]
    private static extern void SetParamA(float paramA);

    [DllImport("__Internal")]
    private static extern void SetParamB(float paramB);

    void Update()
    {
        float xBlue = GameObject.Find("BotBlue").GetComponent<GetBlueVariables>().XBlue;
        float yBlue = GameObject.Find("BotBlue").GetComponent<GetBlueVariables>().YBlue;

        if (xBlue != xBlueOld) {
            #if UNITY_WEBGL && !UNITY_EDITOR
            SetParamA(xBlue);
            #endif
            // Debug.Log("xBlue: " + xBlue);
        }

        if (yBlue != yBlueOld) {
            #if UNITY_WEBGL && !UNITY_EDITOR
            SetParamB(yBlue);
            #endif
            // Debug.Log("yBlue: " + yBlue);
        }
        xBlueOld = xBlue;
        yBlueOld = yBlue;
    }
}
