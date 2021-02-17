using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Energybar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxEnergy(float energy)
    {
        Debug.Log(energy);
        slider.maxValue = energy;
        slider.value = energy;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnergy(float energy)
    {
        slider.value = energy;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
