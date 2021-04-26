using UnityEngine;
using System.Collections;

public class particleHandler : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject Bot;
    private float hSliderValue = 0.1F;
    public float hSliderValueSize = 1.0F;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        Bot = GameObject.Find("BotPurple");
        float botX = (Bot.transform.localPosition.x + 42) / 84;
        float botY = (Bot.transform.localPosition.y + 42) / 84;
        float mouseX = Mathf.Clamp(botX * 0.9F + 0.1F, 0.1F, 1F);
        float mouseY = Mathf.Clamp(botY * 9.4F + 0.3F, 0.3F, 9.7F);

        // changes the speed
        hSliderValue = mouseX;
  
        //changes the size of particles
        hSliderValueSize = mouseY;

        var main = ps.main;
        main.simulationSpeed = hSliderValue;
        main.startSize = hSliderValueSize;

    }

}