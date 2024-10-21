using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private SOHeal healData;

    private int _healAmount;
    private void Start()
    {
        _healAmount = healData.HealAmount;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        IHealthHandler healthHandler = other.GetComponent<IHealthHandler>();
        healthHandler.UpdateHealth(_healAmount);
        Destroy(gameObject);
    }
}
