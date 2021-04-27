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

    float xBlue;
    float yBlue;
    float xBlueOld;
    float yBlueOld;
    float xPurple;
    float yPurple;
    float xPurpleOld;
    float yPurpleOld;
    float xPink;
    float yPink;
    float xPinkOld;
    float yPinkOld;
    float xGreen;
    float yGreen;
    float xGreenOld;
    float yGreenOld;
    float xOrange;
    float yOrange;
    float xOrangeOld;
    float yOrangeOld;

    void Update()
    {   
        if (GameObject.Find("BotBlue"))
        {
            GameObject Bot = GameObject.Find("BotBlue");
            xBlue = ScaleBotVariable(Bot.transform.localPosition.x);
            yBlue = ScaleBotVariable(Bot.transform.localPosition.y);
        }

        if (GameObject.Find("BotPurple"))
        {
            GameObject Bot = GameObject.Find("BotPurple");
            xPurple = ScaleBotVariable(Bot.transform.localPosition.x);
            yPurple = ScaleBotVariable(Bot.transform.localPosition.y);
        }
    
        if (GameObject.Find("BotPink"))
        {
            GameObject Bot = GameObject.Find("BotPink");
            xPink = ScaleBotVariable(Bot.transform.localPosition.x);
            yPink = ScaleBotVariable(Bot.transform.localPosition.y);
        }

        if (GameObject.Find("BotGreen"))
        {
            GameObject Bot = GameObject.Find("BotGreen");
            xGreen = ScaleBotVariable(Bot.transform.localPosition.x);
            yGreen = ScaleBotVariable(Bot.transform.localPosition.y);
        }

        if (GameObject.Find("BotOrange"))
        {
            GameObject Bot = GameObject.Find("BotOrange");
            xOrange = ScaleBotVariable(Bot.transform.localPosition.x);
            yOrange = ScaleBotVariable(Bot.transform.localPosition.y);
        }

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

    float ScaleBotVariable(float var)
    {
        var = (var + 42) / 84;
        var = Mathf.Clamp(Mathf.Round(var * 127), 0, 127);
        return var;
    }
}
