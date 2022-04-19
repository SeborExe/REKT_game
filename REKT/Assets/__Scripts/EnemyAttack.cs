using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 1f;

    public void AttackHitEvent(float damage)
    {
        if (target == null) return;
        Debug.Log("Damage player");
    }
}
