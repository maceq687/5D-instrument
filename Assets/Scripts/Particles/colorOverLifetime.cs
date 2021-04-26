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

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        Bot = GameObject.Find("BotBlue");
        float botX = (Bot.transform.localPosition.x + 42) / 84;
        float botY = (Bot.transform.localPosition.y + 42) / 84;

        float mouseX = Mathf.Clamp(botX, 0, 1);
        float mouseY = Mathf.Clamp(botY, 0, 1);

        hSliderValueR = mouseX;
        hSliderValueB = mouseY;

        var col = ps.colorOverLifetime;
        col.enabled = true;

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] {  new GradientColorKey(Color.red, hSliderValueR), new GradientColorKey(Color.green, hSliderValueG), new GradientColorKey(Color.blue, hSliderValueB) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });

        col.color = grad; 
    }


}