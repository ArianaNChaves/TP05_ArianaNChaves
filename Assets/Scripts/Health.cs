using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private RawImage healthBar;
    [SerializeField] private int maxHealth = 100;
    
    private int _health;

    private void Start()
    {
        _health = maxHealth;
    }
    
    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        
    }

    private void Die()
    {
        //todo AGREGAR ANIMACION, SONIDO, Y PARTICULAS DE MUERTE
        Destroy(gameObject);
    }
}
