using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.5f;

    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (healthSlider.value != easeSlider.value)
        {
            easeSlider.value = Mathf.Lerp(easeSlider.value, health, lerpSpeed * Time.deltaTime);
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            health = 0;
    }
}
