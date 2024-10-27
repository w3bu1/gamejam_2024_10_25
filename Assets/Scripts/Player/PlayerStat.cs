using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{
    [Header("Player Stats")]
    public Slider healthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.5f;
    private float breath = 100f;

    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = Mathf.Lerp(healthSlider.value, health, lerpSpeed * Time.deltaTime);
        }
    }

   public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            health = 0;
    }

    private void Die()
    {
        Debug.Log("Player died");
        // change this to a game over screen
        Application.Quit();
    }
}
