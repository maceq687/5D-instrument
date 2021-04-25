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

    [DllImport("__Internal")]
    private static extern void SetParamE(float paramE);

    [DllImport("__Internal")]
    private static extern void SetParamF(float paramF);

    [DllImport("__Internal")]
    private static extern void SetParamG(float paramG);

    [DllImport("__Internal")]
    private static extern void SetParamH(float paramH);

    [DllImport("__Internal")]
    private static extern void SetParamI(float paramI);

    [DllImport("__Internal")]
    private static extern void SetParamJ(float paramJ);

    float xBlueOld;
    float yBlueOld;
    float xPurpleOld;
    float yPurpleOld;
    float xPinkOld;
    float yPinkOld;
    float xGreenOld;
    float yGreenOld;
    float xOrangeOld;
    float yOrangeOld;

    void Update()
    {
        float xBlue = GameObject.Find("BotBlue").GetComponent<GetBlueVariables>().XBlue;
        float yBlue = GameObject.Find("BotBlue").GetComponent<GetBlueVariables>().YBlue;
        float xPurple = GameObject.Find("BotPurple").GetComponent<GetPurpleVariables>().XPurple;
        float yPurple = GameObject.Find("BotPurple").GetComponent<GetPurpleVariables>().YPurple;
        float xPink = GameObject.Find("BotPink").GetComponent<GetPinkVariables>().XPink;
        float yPink = GameObject.Find("BotPink").GetComponent<GetPinkVariables>().YPink;
        float xGreen = GameObject.Find("BotGreen").GetComponent<GetGreenVariables>().XGreen;
        float yGreen = GameObject.Find("BotGreen").GetComponent<GetGreenVariables>().YGreen;
        float xOrange = GameObject.Find("BotOrange").GetComponent<GetOrangeVariables>().XOrange;
        float yOrange = GameObject.Find("BotOrange").GetComponent<GetOrangeVariables>().YOrange;

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

        if (xPink != xPinkOld) {
            #if UNITY_WEBGL && !UNITY_EDITOR
            SetParamE(xPink);
            #endif
        }

        if (yPink != yPinkOld) {
            #if UNITY_WEBGL && !UNITY_EDITOR
            SetParamF(yPink);
            #endif
        }

        if (xGreen != xGreenOld) {
            #if UNITY_WEBGL && !UNITY_EDITOR
            SetParamG(xGreen);
            #endif
        }

        if (yGreen != yGreenOld) {
            #if UNITY_WEBGL && !UNITY_EDITOR
            SetParamH(yGreen);
            #endif
        }

        if (xOrange != xOrangeOld) {
            #if UNITY_WEBGL && !UNITY_EDITOR
            SetParamI(xOrange);
            #endif
        }

        if (yOrange != yOrangeOld) {
            #if UNITY_WEBGL && !UNITY_EDITOR
            SetParamJ(yOrange);
            #endif
        }

        xBlueOld = xBlue;
        yBlueOld = yBlue;
        xPurpleOld = xPurple;
        yPurpleOld = yPurple;
        xPinkOld = xPink;
        yPinkOld = yPink;
        xGreenOld = xGreen;
        yGreenOld = yGreen;
        xOrangeOld = xOrange;
        yOrangeOld = yOrange;
    }
}
