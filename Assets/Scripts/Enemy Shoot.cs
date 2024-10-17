using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate;

    private float _timeToShoot = 0;
    private bool _canShoot = false;
    private bool _seePlayer = false;

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
        if (_timeToShoot >= fireRate && _seePlayer)
        {
            _canShoot = true;
        }
    }
    private void Shoot()
    {
        if (!_canShoot) return;
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        ResetShootTime();
    }

    private void ResetShootTime()
    {
        _canShoot = false;
        _timeToShoot = 0;
    }
}
