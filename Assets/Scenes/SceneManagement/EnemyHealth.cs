using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public float currentHealth;

    public event Action<float> OnDied;

    public float OnEnemyDied { get => maxHealth; set =>maxHealth=  value; }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void ChangeHealth(float amount)
    {
        currentHealth += amount;

        float currentHealthPercentage = currentHealth / maxHealth;

        if( currentHealth<= 0 && OnDied != null)
        {
            OnDied(maxHealth);
            Destroy(gameObject);
        }
    }

    public void ApplyDamage(float amount )
    {
        ChangeHealth(-amount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            ApplyDamage(10);
    }
}
