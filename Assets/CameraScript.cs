using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

        if (mouseXDelta != 0 && xWithin == true && yWithin == true)
            Debug.Log("X: " + mouseX); // WIP
        
        if (mouseYDelta != 0 && xWithin == true && yWithin == true)
            Debug.Log("Y: " + mouseY); // WIP

        lastMouseX = mouseX;
        lastMouseY = mouseY;
    }
}
