using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private SOPlayer playerData;
    
    private float _fireRate;
    private float _timeToShoot = 0;
    private bool _canShoot = true;
    private bool _isAttacking = false;
    private bool _hasFireRate = true;

    private void Start()
    {
        _fireRate = playerData.FireRate;
    }

    private void Update()
    {
        _timeToShoot += Time.deltaTime;
        
        ValidateShoot();
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)
        {
            Shoot();
            _isAttacking = true;
        }
        else
        {
            _isAttacking = false;

        }

    }

    private void ValidateShoot()
    {
        if (_timeToShoot >= _fireRate || !_hasFireRate)
        {
            _canShoot = true;
        }
    }

    private void Shoot()
    {
        AudioManager.Instance.PlayEffect("Gunshot");
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        ResetShootTime();
    }

    private void ResetShootTime()
    {
        _canShoot = false;
        _timeToShoot = 0;
    }

    public bool GetIsAttacking()
    {
        return _isAttacking;
    }

    public bool HasFireRate{ get => _hasFireRate; set => _hasFireRate = value; }
}
