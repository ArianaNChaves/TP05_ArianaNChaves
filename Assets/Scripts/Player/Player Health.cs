using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealthHandler
{
    public event Action PlayerDeath;
    
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject particles;
    [SerializeField] private SOPlayer playerData;
    
    private int _health;
    private int _maxHealth;
    private void Start()
    {
        _maxHealth = playerData.MaxHealth;
        _health = _maxHealth;
        UpdateHealthBar();
    }
    
    public void UpdateHealth(int amount)
    {
        HealthChangedSound(amount);
        _health += amount;
        if (_health <= 0)
        {
            Die();
        }
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float clampedHealth = Mathf.Clamp(_health, 0, _maxHealth);
        healthBar.fillAmount = clampedHealth / _maxHealth;
    }

    private void Die()
    {
        PlayerDeath?.Invoke();
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(gameObject,0.01f);
    }

    private void HealthChangedSound(int amount)
    {
        if (amount >= 0)
        {
            AudioManager.Instance.PlayEffect("Pickup");
        }
        else
        {
            AudioManager.Instance.PlayEffect("Player Hit");

        }
    }
}
