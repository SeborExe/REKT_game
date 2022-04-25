using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    DeathHandler deathHandler;

    [SerializeField] float maxHealth = 50f;
    float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        deathHandler = GetComponent<DeathHandler>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            deathHandler.HandleDeath();
        }
    }
}
