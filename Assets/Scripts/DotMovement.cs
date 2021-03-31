using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMovement : MonoBehaviour
{
    public float min;
    public float max;
    public float smoothTime = 1F;

    private Vector3 velocity = Vector3.zero;

    private float x;
    private float y;
    private float z;
    private bool downPressed = false ;

    private Vector3 newpos;


    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        x = Random.Range(min, max);
        y = Random.Range(min, max);
        z = 0;
        newpos = new Vector3(x, y, z);

        transform.position = Vector3.SmoothDamp(transform.position, newpos, ref velocity, smoothTime);
    }
}
