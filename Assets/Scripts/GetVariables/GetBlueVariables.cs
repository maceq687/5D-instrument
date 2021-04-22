using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBlueVariables : MonoBehaviour
{
    public float XBlue;
    public float YBlue;
    bool xWithin = false;
    bool yWithin = false;
    bool dotWithinC = false;
    float lastDotX;
    float lastDotY;
   
    void Update()
    {
        float xRelative = (transform.localPosition.x + 42) / 84;
        float yRelative = (transform.localPosition.y + 42) / 84;

        if (xRelative > 0 && xRelative < 1 ) { xWithin = true; }
        else { xWithin = false; }
        if (yRelative > 0 && yRelative < 1 ) { yWithin = true; }
        else { yWithin = false; }

        float dotX = Mathf.Clamp(Mathf.Round(xRelative * 127), 0, 127);
        float dotY = Mathf.Clamp(Mathf.Round(yRelative * 127), 0, 127);

        float dotXDelta = dotX - lastDotX;
        float dotYDelta = dotY - lastDotY;

        if (xWithin == true && yWithin == true)
            { 
                dotWithinC = true;
            }
        else
            {
                dotWithinC = false;
            }

        if (dotXDelta != 0 && dotWithinC == true)
            {
                // Debug.Log("dotX: " + dotX);
                XBlue = dotX;
            }
        
        if (dotYDelta != 0 && dotWithinC == true)
            {   
                // Debug.Log("dotY: " + dotY);
                YBlue = dotY;
            }

        lastDotX = dotX;
        lastDotY = dotY;
    }
}
