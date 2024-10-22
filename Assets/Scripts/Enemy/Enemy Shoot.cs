using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private SOEnemy enemyData;
    
    private float _fireRate;
    private float _timeToShoot = 0;
    private bool _canShoot = false;
    private bool _seePlayer = false;

    private void Start()
    {
        _fireRate = enemyData.FireRate;
    }

    private void Update()
    {
        _timeToShoot += Time.deltaTime;
        
        ValidateShoot();
        Shoot();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        _seePlayer = true; 
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        _seePlayer = false;
    }
    
    private void ValidateShoot()
    {
        if (_timeToShoot >= _fireRate && _seePlayer)
        {
            _canShoot = true;
        }
    }
    private void Shoot()
    {
        if (!_canShoot) return;
        AudioManager.Instance.PlayEffect("Enemy Attack");
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        ResetShootTime();
    }

    private void ResetShootTime()
    {
        _canShoot = false;
        _timeToShoot = 0;
    }
}
