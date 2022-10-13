using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    public float currentHealth;

    public UnityEvent OnPlayerDied;

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    private void ChangeHealth(float amount)
    {
        currentHealth += amount;

        float currentHealthPercentage = currentHealth / maxHealth;

        if (currentHealth <= 0 )
        {
            OnPlayerDied.Invoke();
            Destroy(gameObject);
        }
    }

    public void ApplyDamage(float amount)
    {
        ChangeHealth(-amount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            ApplyDamage(10);
    }
}
