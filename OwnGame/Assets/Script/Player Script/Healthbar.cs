using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI anzeige der Lebenspunkte

public class Healthbar : MonoBehaviour
{
    [Header("Slider")]
    public Slider slider;
    [Header("Gradient")]
    public Gradient gradient;
    [Header("Image")]
    public Image fill;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

   

}
