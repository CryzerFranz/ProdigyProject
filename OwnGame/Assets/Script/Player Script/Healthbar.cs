using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private Animator animator;
    private bool isPlayerDead = false;

    void Update()
    {
        Debug.Log(slider.value);
        if (isPlayerDead)
        {
            animator.SetBool("PlayerDead", true);
            ////////// TESTPHASE
            //Time.timeScale = 0f;
        }
    }

    void Start()
    {
        animator = GameObject.Find("Cyber samurai").GetComponent<Animator>();
    }

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
        isPlayerDead = isDead();
       
    }

    public bool isDead()
    {
        if (slider.value <= 0)
        {
            return true;
        }
        return false;
    }

}
