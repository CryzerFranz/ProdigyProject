using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class AbilityTImeBar : MonoBehaviour
{
    [Header("Slider")]
    public Slider slider;
    [Header("Gradient")]
    public Gradient gradient;
    [Header("Image")]
    public Image fill;

    public AbilityProzentTimeBar abilityKeyPosition;

    public GradientColorKey[] colorKey;
    GradientAlphaKey[] alphaKey;

    [SerializeField]
    private Movement playerMovement;

    //vll nicht mehr notwendig
    private float sliderAdditionsValue = 1;

    private void Start()
    {

        slider.maxValue = 1.0f; //default value
        slider.value = 0.0f;
        sliderAdditionsValue = 0.0f;

        colorKey = new GradientColorKey[3];
        alphaKey = new GradientAlphaKey[3];

        colorKey[0].color = new Color32(171, 132, 200, 0);
        colorKey[1].color = new Color32(223, 161, 224, 0);
        colorKey[2].color = new Color32(171, 132, 200, 0);

        alphaKey[0].alpha = 1.0f;
        alphaKey[1].alpha = 1.0f;
        alphaKey[2].alpha = 1.0f;
        colorKey[2].time = 1.0f;
        alphaKey[2].time = 1.0f;
    }

    public void setKeyGradientValue(float value_01, float value_02)
    {
        colorKey[0].time = value_01;
        colorKey[1].time = value_02;
        alphaKey[0].time = value_01;
        alphaKey[1].time = value_02;

        gradient.SetKeys(colorKey, alphaKey);
    }
    public void setSliderAdditionsValue(float value)
    {
        sliderAdditionsValue = value;
    }

    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = 0;
    }

    public void SetValue()
    {
        slider.value += 1;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        
    }

    public void changeGradientValue(float value_01, float value_02)
    {
       
    }
}
