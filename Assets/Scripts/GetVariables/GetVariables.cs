using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class GetVariables : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SetParamA(float paramA);

    [DllImport("__Internal")]
    private static extern void SetParamB(float paramB);

    [DllImport("__Internal")]
    private static extern void SetParamC(float paramC);

    [DllImport("__Internal")]
    private static extern void SetParamD(float paramD);

    float xBlueOld;
    float yBlueOld;
    float xPurpleOld;
    float yPurpleOld;

    void Update()
    {
        float xBlue = GameObject.Find("BotBlue").GetComponent<GetBlueVariables>().XBlue;
        float yBlue = GameObject.Find("BotBlue").GetComponent<GetBlueVariables>().YBlue;
        float xPurple = GameObject.Find("BotPurple").GetComponent<GetPurpleVariables>().XPurple;
        float yPurple = GameObject.Find("BotPurple").GetComponent<GetPurpleVariables>().YPurple;

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
        if (xPurple != xPurpleOld) {
            #if UNITY_WEBGL && !UNITY_EDITOR
            SetParamC(xPurple);
            #endif
        }

        if (yPurple != yPurpleOld) {
            #if UNITY_WEBGL && !UNITY_EDITOR
            SetParamD(yPurple);
            #endif
        }

        xBlueOld = xBlue;
        yBlueOld = yBlue;
        xPurpleOld = xPurple;
        yPurpleOld = yPurple;
    }
}
