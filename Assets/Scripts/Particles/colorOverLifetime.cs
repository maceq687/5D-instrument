using UnityEngine;
using System.Collections;

public class colorOverLifetime : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValueR = 0.0F;
    public float hSliderValueG = 0.0F;
    public float hSliderValueB = 0.0F;
    public float hSliderValueA = 1.0F;
    private GameObject Bot;
    float botX;
    float botY;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (GameObject.Find("BotPink"))
        {
            Bot = GameObject.Find("BotPink");
            botX = (Bot.transform.localPosition.x + 42) / 84;
            botY = (Bot.transform.localPosition.y + 42) / 84;
            botX = Mathf.Clamp(botX, 0, 1);
            botY = Mathf.Clamp(botY, 0, 1);
        }
        
        //changes the color
        hSliderValueR = botX;
        hSliderValueB = botY;

        var col = ps.colorOverLifetime;
        col.enabled = true;

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] {  new GradientColorKey(Color.red, hSliderValueR), new GradientColorKey(Color.green, hSliderValueG), new GradientColorKey(Color.blue, hSliderValueB) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad; 
    }


}