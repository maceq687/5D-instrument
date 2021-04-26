using UnityEngine;
using System.Collections;

public class numberOfParticles : MonoBehaviour
{
    private ParticleSystem ps;
    private GameObject Bot;
    private float hSliderValue = 2.5F;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        Bot = GameObject.Find("BotOrange");
        float botX = (Bot.transform.localPosition.x + 42) / 84;
        float botY = (Bot.transform.localPosition.y + 42) / 84;
        float mouseX = Mathf.Clamp(Mathf.Round(botX * 65 + 5), 5, 70);
        float mouseY = Mathf.Clamp(Mathf.Round(botY * 127), 0, 127);

        hSliderValue = mouseX;

        if (hSliderValue < 200)
        {
            var emission = ps.emission;
            emission.rateOverTime = hSliderValue;
        }

    }


}