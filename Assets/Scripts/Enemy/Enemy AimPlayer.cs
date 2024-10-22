using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        AimThePlayer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AimThePlayer();
    }

    private void AimThePlayer()
    {
        if (player == null) return;
        Vector2 direction = (player.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
