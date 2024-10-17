using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int amountToHeal = 10;


    private void OnTriggerEnter2D(Collider2D other)
    {
        IHealthHandler healthHandler = other.GetComponent<IHealthHandler>();
        healthHandler.UpdateHealth(amountToHeal);
        Destroy(gameObject);
    }
}
