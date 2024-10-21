using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    [SerializeField] private Color powerUpColor;
    [SerializeField] private float powerUpTimeCondition;
    
    private SpriteRenderer _spriteRenderer;
    private PlayerShoot _playerShootScript;
    private Color _defaultColor;
    private float _timeWithoutTakeDamageTimer = 0;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerShootScript = GetComponent<PlayerShoot>();
    }

    private void Start()
    {
        _defaultColor = _spriteRenderer.color;
    }

    private void Update()
    {
        _timeWithoutTakeDamageTimer += Time.deltaTime;
        PowerUp();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _timeWithoutTakeDamageTimer = 0;
            _spriteRenderer.color = _defaultColor;
            _playerShootScript.HasFireRate = true;
        }
    }

    private void PowerUp()
    {
        if (_timeWithoutTakeDamageTimer >= powerUpTimeCondition)
        {
            _spriteRenderer.color = powerUpColor;
            _playerShootScript.HasFireRate = false;
        }
    }
 
}
