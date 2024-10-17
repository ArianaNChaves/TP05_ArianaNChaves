using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime = 5.0f;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Shot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        damageable.UpdateHealth(-damage);
        Destroy(gameObject);
    }
    private void Destroy()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Shot()
    {
        _rigidbody2D.velocity = new Vector2(transform.right.x, transform.right.y) * speed;
        Destroy();
    }
}
