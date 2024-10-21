using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IHealthHandler
{
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject particles;
    [SerializeField] private int maxHealth = 100;
    
    private int _health;

    private void Start()
    {
        _health = maxHealth;
        UpdateHealthBar();
    }
    
    public void UpdateHealth(int amount)
    {
        _health += amount;
        if (_health <= 0)
        {
            Die();
        }
        if (_health > maxHealth)
        {
            _health = maxHealth;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float clampedHealth = Mathf.Clamp(_health, 0, maxHealth);
        healthBar.fillAmount = clampedHealth / maxHealth;
    }

    private void Die()
    {
        //todo AGREGAR ANIMACION, SONIDO, Y PARTICULAS DE MUERTE
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject,0.01f);
    }
}
