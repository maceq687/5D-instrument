using UnityEngine;
using System.Collections;

public class sizeOfParticles : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject Bot;
    private float hSliderValueX = 1.0F;
    private float hSliderValueY = 1.0F;
    private float meanValue;
    float botX = 4f;
    float botY = 4f;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (GameObject.Find("BotOrange"))
        {
            Bot = GameObject.Find("BotOrange");
            botX = (Bot.transform.localPosition.x + 42) / 84;
            botY = (Bot.transform.localPosition.y + 42) / 84;
            botX = Mathf.Clamp(botX * 9.4F + 0.3F, 0.3F, 9.7F);
            botY = Mathf.Clamp(botX * 9.4F + 0.3F, 0.3F, 9.7F);
        }
        
        hSliderValueX = botX;
        hSliderValueY = botY;

        meanValue = meanValue = (hSliderValueX + hSliderValueY) /2;
  
        //changes the size of particles
        var main = ps.main;
        main.startSize = meanValue;

    }

}
