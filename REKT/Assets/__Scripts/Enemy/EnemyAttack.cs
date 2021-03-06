using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 10f;

    private void Awake()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent(float damage)
    {
        if (target == null) return;

        target.TakeDamage(damage);
    }
}
