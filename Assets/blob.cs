using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blob : MonoBehaviour
{
    Vector3 rndPosition;
    Vector3 worldPosition;
    public Transform ObjectToMove;
    bool PlayerPresent = false;

    void Start()
    {
        InvokeRepeating("CalculateNewPos", 0.1f, 0.1f);
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1f;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        MoveObject();
        if (Input.GetMouseButtonDown(0)){
            PlayerPresent = !PlayerPresent;
        }
    }

    void CalculateNewPos() {
            Vector3 minPosition = Camera.main.ScreenToWorldPoint(Vector3.forward);
            Vector3 resolution = new Vector3(Screen.width, Screen.height, 1);
            Vector3 maxPosition = Camera.main.ScreenToWorldPoint(resolution);
            float xMin = minPosition.x;
            float xMax = maxPosition.x;
            float yMin = minPosition.y;
            float yMax = maxPosition.y;
            rndPosition.Set(Random.Range(xMin, xMax), Random.Range(yMin, yMax), -9);
        }

    void MoveObject() {
        if (PlayerPresent == false) {
            ObjectToMove.position = rndPosition;
        }   else {
            ObjectToMove.position = worldPosition;
        }
    
    }
}
