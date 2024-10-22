using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterKill : MonoBehaviour
{
    private const int KillDamage = -99999;
    private void OnCollisionEnter2D(Collision2D other)
    {
        IHealthHandler healthHandler = other.gameObject.GetComponent<IHealthHandler>();
        healthHandler.UpdateHealth(KillDamage);
    }
}
