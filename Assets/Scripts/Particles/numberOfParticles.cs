using UnityEngine;
using System.Collections;

public class numberOfParticles : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject Bot;
    private float hSliderValue = 2.5F;
    float botX;
    float botY;

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
            botX = Mathf.Clamp(Mathf.Round(botX * 65 + 5), 5, 70);
            botY = Mathf.Clamp(Mathf.Round(botY * 127), 0, 127);
        }
        
        hSliderValue = botX;

        if (hSliderValue < 200)
        {
            var emission = ps.emission;
            emission.rateOverTime = hSliderValue;
        }

    }


}