using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "ScriptableObjects/Enemy Data")]
public class SOEnemy : ScriptableObject
{
    [Header("Enemy Health Settings")]
    [SerializeField] private int maxHealth;
    
    [Header("Enemy Bullet Settings")]
    [SerializeField] private int damage;
    [SerializeField] private float fireRate;
    [SerializeField] private float velocity;
    [SerializeField] private float lifeTime;
    
    
    public int Damage{ get => damage; set => damage = value; }
    public float Velocity { get => velocity; set => velocity = value; }
    public float LifeTime { get => lifeTime; set => lifeTime = value; }
    public int MaxHealth{ get => maxHealth; set => maxHealth = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
}
