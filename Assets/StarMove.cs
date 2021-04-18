using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StarMove : MonoBehaviour
{
    void Start()
    {
        // string test = "{\"xHand\":1,\"yHand\":0}";
        // Debug.Log(test);
        // Move(test);
    }

    public void Move(string args)
    {
        Coordinates cord = JsonUtility.FromJson<Coordinates>(args);
        double x = (double)cord.xHand;
        double y = (double)cord.yHand;
        x = (x - 0.5) * 4;
        y = (-y + 0.5) * 4;
        float xFloat = (float)x;
        float yFloat = (float)y;
        transform.position = new Vector3(xFloat, yFloat, -5);
    }
}

[Serializable]
public class Coordinates
{
    public double xHand;
    public double yHand;
} 
