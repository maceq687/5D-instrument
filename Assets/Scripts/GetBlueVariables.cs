using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBlueVariables : MonoBehaviour
{
    public float XBlue;
    public float YBlue;
    bool xWithin = false;
    bool yWithin = false;
    bool mouseWithinC = false;
    float lastMouseX;
    float lastMouseY;
   
    void Update()
    {
        float xRelative = (transform.localPosition.x + 42) / 84;
        float yRelative = (transform.localPosition.y + 42) / 84;

        if (xRelative > 0 && xRelative < 1 ) { xWithin = true; }
        else { xWithin = false; }
        if (yRelative > 0 && yRelative < 1 ) { yWithin = true; }
        else { yWithin = false; }

        float mouseX = Mathf.Clamp(Mathf.Round(xRelative * 127), 0, 127);
        float mouseY = Mathf.Clamp(Mathf.Round(yRelative * 127), 0, 127);

        float mouseXDelta = mouseX - lastMouseX;
        float mouseYDelta = mouseY - lastMouseY;

        if (xWithin == true && yWithin == true)
            { 
                mouseWithinC = true;
            }
        else
            {
                mouseWithinC = false;
            }

        if (mouseXDelta != 0 && mouseWithinC == true)
            {
                // Debug.Log("mouseX: " + mouseX);
                XBlue = mouseX;
            }
        
        if (mouseYDelta != 0 && mouseWithinC == true)
            {   
                // Debug.Log("mouseY: " + mouseY);
                YBlue = mouseY;
            }

        lastMouseX = mouseX;
        lastMouseY = mouseY;
    }
}
