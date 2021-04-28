using UnityEngine;
using System.Collections;

public class numberOfParticles : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject Bot;
    private float hSliderValueX = 2.5F;
    private float hSliderValueY = 2.5F;
    private float meanValue;
    float botX;
    float botY;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (GameObject.Find("BotPurple"))
        {
            Bot = GameObject.Find("BotPurple");
            botX = (Bot.transform.localPosition.x + 42) / 84;
            botY = (Bot.transform.localPosition.y + 42) / 84;
            botX = Mathf.Clamp(Mathf.Round(botX * 65 + 5), 5, 70);
            botY = Mathf.Clamp(Mathf.Round(botX * 65 + 5), 5, 70);
        }
        
        hSliderValueX = botX;
        hSliderValueY = botY;
        //changers the number of particles
        meanValue = (hSliderValueX + hSliderValueY) /2;

        if (meanValue < 200)
        {
            var emission = ps.emission;
            emission.rateOverTime = meanValue;
        }


    }


}