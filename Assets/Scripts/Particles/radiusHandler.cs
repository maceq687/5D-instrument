using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class radiusHandler : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject Bot;
    public float radius = 0.01f;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update(){
        Bot = GameObject.Find("BotPink");
        float botX = (Bot.transform.localPosition.x + 42) / 84;
        float botY = (Bot.transform.localPosition.y + 42) / 84;
        float mouseX = Mathf.Clamp(botX * 7.9F + 0.1F, 0.1F, 8);
        float mouseY = Mathf.Clamp(Mathf.Round(botY * 127), 0, 127);

        radius = mouseX;
        // Debug.Log(radius);

        var shape = ps.shape;
        shape.radius = radius;

    }
}