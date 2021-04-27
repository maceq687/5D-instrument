using UnityEngine;
using System.Collections;

public class particleHandler : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject Bot;
    private float hSliderValue = 0.1F;
    public float hSliderValueSize = 1.0F;
    float botX;
    float botY;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (GameObject.Find("BotBlue"))
        {
            Bot = GameObject.Find("BotBlue");
            botX = (Bot.transform.localPosition.x + 42) / 84;
            botY = (Bot.transform.localPosition.y + 42) / 84;
            botX = Mathf.Clamp(botX * 0.9F + 0.1F, 0.1F, 1F);
            botY = Mathf.Clamp(botY * 9.4F + 0.3F, 0.3F, 9.7F);
        }
        
        

        // changes the speed
        hSliderValue = botX;
  
        //changes the size of particles
        hSliderValueSize = botY;

        var main = ps.main;
        main.simulationSpeed = hSliderValue;
        main.startSize = hSliderValueSize;

    }

}