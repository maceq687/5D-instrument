using UnityEngine;
using System.Collections;

public class particleHandler : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject Bot;
    private float hSliderValueX = 0.5F;
    private float hSliderValueY = 0.5F;
    private float meanValue;
    //public float hSliderValueSize = 1.0F;
    float botX = 0.5f;
    float botY = 0.5f;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (GameObject.Find("BotGreen"))
        {
            Bot = GameObject.Find("BotGreen");
            botX = (Bot.transform.localPosition.x + 42) / 84;
            botY = (Bot.transform.localPosition.y + 42) / 84;
            botX = Mathf.Clamp(botX * 0.9F + 0.1F, 0.1F, 1F);
            botY = Mathf.Clamp(botX * 0.9F + 0.1F, 0.1F, 1F);
        }
        
        // changes the speed
        hSliderValueX = botX;
        hSliderValueY = botY;

        meanValue = (hSliderValueX + hSliderValueY) /2;

        var main = ps.main;
        main.simulationSpeed = meanValue;
    }

}