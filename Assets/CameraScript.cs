using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CameraScript : MonoBehaviour
{    
    float mouseX;
    float mouseY;
    float mouseXDelta;
    float mouseYDelta;
    float lastMouseX;
    float lastMouseY;
    float xRelative;
    float yRelative;
    bool xWithin = false;
    bool yWithin = false;
    bool mouseWithinC = false;
    float selectedPlayer = 1;

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

    [DllImport("__Internal")]
    private static extern void MouseWithin(bool mouseWithin = false);
    
    void Start()
    {

    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
            {
                // Debug.Log(mousePos.x);
                // Debug.Log(mousePos.y);
                xRelative = mousePos.x / Screen.width;
                yRelative = mousePos.y / Screen.height;
                if (xRelative > 0 && xRelative < 1 ) { xWithin = true; }
                else { xWithin = false; }
                if (yRelative > 0 && yRelative < 1 ) { yWithin = true; }
                else { yWithin = false; }
                mouseX = Mathf.Clamp(Mathf.Round(xRelative * 127), 0, 127);
                mouseY = Mathf.Clamp(Mathf.Round(yRelative * 127), 0, 127);
            }
        mouseXDelta = mouseX - lastMouseX;
        mouseYDelta = mouseY - lastMouseY;

        if (xWithin == true && yWithin == true)
            { 
                mouseWithinC = true;
                #if UNITY_WEBGL && !UNITY_EDITOR
                MouseWithin(true);
                #endif
            }
        else
            {
                mouseWithinC = false;
                #if UNITY_WEBGL && !UNITY_EDITOR
                MouseWithin(false);
                #endif
            }

        if (Input.GetKeyDown("1"))
            { selectedPlayer = 1; }
        else if (Input.GetKeyDown("2"))
            { selectedPlayer = 2; }
        else if (Input.GetKeyDown("3"))
            { selectedPlayer = 3; }
        else if (Input.GetKeyDown("4"))
            { selectedPlayer = 4; }
        else if (Input.GetKeyDown("5"))
            { selectedPlayer = 5; }
        else {}

        // Debug.Log("Selected player: " + selectedPlayer);

        if (mouseXDelta != 0 && mouseWithinC == true && selectedPlayer == 1)
            {
                // Debug.Log("X: " + mouseX); // WIP
                #if UNITY_WEBGL && !UNITY_EDITOR
                SetParamA(mouseX);
                #endif
            }
        
        if (mouseYDelta != 0 && mouseWithinC == true && selectedPlayer == 1)
            {   
                // Debug.Log("Y: " + mouseY); // WIP
                #if UNITY_WEBGL && !UNITY_EDITOR
                SetParamB(mouseY);
                #endif
            }

        if (mouseXDelta != 0 && mouseWithinC == true && selectedPlayer == 2)
            {   
                #if UNITY_WEBGL && !UNITY_EDITOR
                SetParamC(mouseX);
                #endif
            }

        if (mouseYDelta != 0 && mouseWithinC == true && selectedPlayer == 2)
            {   
                #if UNITY_WEBGL && !UNITY_EDITOR
                SetParamD(mouseY);
                #endif
            }

        if (mouseXDelta != 0 && mouseWithinC == true && selectedPlayer == 3)
            {   
                #if UNITY_WEBGL && !UNITY_EDITOR
                SetParamE(mouseX);
                #endif
            }

        if (mouseYDelta != 0 && mouseWithinC == true && selectedPlayer == 3)
            {   
                #if UNITY_WEBGL && !UNITY_EDITOR
                SetParamF(mouseY);
                #endif
            }

        if (mouseXDelta != 0 && mouseWithinC == true && selectedPlayer == 4)
            {   
                #if UNITY_WEBGL && !UNITY_EDITOR
                SetParamG(mouseX);
                #endif
            }

        if (mouseYDelta != 0 && mouseWithinC == true && selectedPlayer == 4)
            {   
                #if UNITY_WEBGL && !UNITY_EDITOR
                SetParamH(mouseY);
                #endif
            }

        if (mouseXDelta != 0 && mouseWithinC == true && selectedPlayer == 5)
            {   
                #if UNITY_WEBGL && !UNITY_EDITOR
                SetParamI(mouseX);
                #endif
            }

        if (mouseYDelta != 0 && mouseWithinC == true && selectedPlayer == 5)
            {   
                #if UNITY_WEBGL && !UNITY_EDITOR
                SetParamJ(mouseY);
                #endif
            }

        lastMouseX = mouseX;
        lastMouseY = mouseY;
    }
}