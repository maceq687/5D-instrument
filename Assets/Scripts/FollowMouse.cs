using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    private float x;
    private float y;
    private float z;

    private Vector3 newpos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 102;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);


        transform.position = Vector3.MoveTowards(transform.position, worldPosition, 10);
    }
}
