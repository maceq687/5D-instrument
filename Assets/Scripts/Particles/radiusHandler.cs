using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class radiusHandler : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject Bot;
    private float radiusX = 0.01f;
    private float radiusY = 0.01f;
    private float meanRadius = 4f;
    float botX;
    float botY;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update(){
        if (GameObject.Find("BotBlue"))
        {
            Bot = GameObject.Find("BotBlue");
            botX = (Bot.transform.localPosition.x + 42) / 84;
            botY = (Bot.transform.localPosition.y + 42) / 84;
            botX = Mathf.Clamp(botX * 7.9F + 0.1F, 0.1F, 8);
            botY = Mathf.Clamp(botX * 7.9F + 0.1F, 0.1F, 8);
        }
        
        radiusX = botX;
        radiusY = botY;

        meanRadius = (radiusX + radiusY) /2;
    
        var shape = ps.shape;
        shape.radius = meanRadius;

    }
}