using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStat : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;

    [Header("GUI")]
    public Slider healthBar;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if (healthBar == null)
            return;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            LevelUtils.instance.UpdateScore(10);
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
