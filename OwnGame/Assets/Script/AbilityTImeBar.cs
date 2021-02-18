using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityTImeBar : MonoBehaviour
{
    [Header("Slider")]
    public Slider slider;
    [Header("Gradient")]
    public Gradient gradient;
    [Header("Image")]
    public Image fill;

    private float maxValue;

    public float getMaxValue()
    {
        return maxValue;
    }
    public void SetMaxValue(float value)
    {
        maxValue = value;
        slider.maxValue = value;
        slider.value = value;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(float value)
    {
        slider.value -= value;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
