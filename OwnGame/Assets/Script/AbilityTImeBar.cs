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

    private float maxValue = 100;

    private void Start()
    {
        slider.maxValue = maxValue; //default value
    }

    public float getMaxValue()
    {
        return maxValue;
    }
    public void SetMaxValue(float value)
    {
        maxValue = value;
        slider.maxValue = maxValue;
        slider.value = 0;
    }

    public void SetValue(float value)
    {
        Debug.Log(value);
        slider.value += value;
        Debug.Log(slider.value);
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
