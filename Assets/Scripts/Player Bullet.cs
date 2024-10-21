using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private SOPlayer bulletData;
    
    private int _damage;
    private float _speed;
    private float _lifeTime = 5.0f;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _damage = bulletData.Damage;
        _speed = bulletData.Velocity;
        _lifeTime = bulletData.LifeTime;
        
        Shot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IHealthHandler healthHandler = collision.gameObject.GetComponent<IHealthHandler>();
        healthHandler.UpdateHealth(-_damage);
        Destroy(gameObject);
    }
    private void Destroy()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Shot()
    {
        _rigidbody2D.velocity = new Vector2(transform.right.x, transform.right.y) * _speed;
        Destroy();
    }
}
