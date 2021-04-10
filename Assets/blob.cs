using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blob : MonoBehaviour
{
    Vector3 rndPosition;
    Vector3 worldPosition;
    public Transform ObjectToMove;
    bool PlayerPresent = false;
    public float planeDistance = 4;
    public float yCamRot;
    float absolutePlaneDistance;

    void Start()
    {
        InvokeRepeating("CalculateNewPos", 0.1f, 0.1f);
        float zCam = Camera.main.transform.position.z;
        absolutePlaneDistance = zCam + planeDistance;
        Quaternion camRotation = Camera.main.transform.rotation;
        yCamRot = Camera.main.transform.rotation.y;
        ObjectToMove.rotation = camRotation;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = planeDistance;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        MoveObject();
        if (Input.GetMouseButtonDown(0)){
            PlayerPresent = !PlayerPresent;
        }
    }

    void CalculateNewPos() {
            Vector3 refZero = new Vector3(0, 0, planeDistance);
            Vector3 minPosition = Camera.main.ScreenToWorldPoint(refZero);
            Vector3 resolution = new Vector3(Screen.width, Screen.height, planeDistance);
            Vector3 maxPosition = Camera.main.ScreenToWorldPoint(resolution);
            rndPosition.Set(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), absolutePlaneDistance);
        }

    void MoveObject() {
        if (PlayerPresent == false) {
            ObjectToMove.position = rndPosition;
        }   else {
            ObjectToMove.position = worldPosition;
        }
    
    }
}
