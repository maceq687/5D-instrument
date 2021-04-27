using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class radiusHandler : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject Bot;
    public float radius = 0.01f;
    float botX;
    float botY;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update(){
        if (GameObject.Find("BotPink"))
        {
            Bot = GameObject.Find("BotPink");
            botX = (Bot.transform.localPosition.x + 42) / 84;
            botY = (Bot.transform.localPosition.y + 42) / 84;
            botX = Mathf.Clamp(botX * 7.9F + 0.1F, 0.1F, 8);
            botY = Mathf.Clamp(Mathf.Round(botY * 127), 0, 127);
        }
        
        radius = botX;
    
        var shape = ps.shape;
        shape.radius = radius;

    }
}