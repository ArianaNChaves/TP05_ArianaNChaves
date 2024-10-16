using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    //private bool _seePlayer = false;
    
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        //_seePlayer = true;
        AimThePlayer();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        //_seePlayer = false;
    }
    
    
    private void AimThePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
