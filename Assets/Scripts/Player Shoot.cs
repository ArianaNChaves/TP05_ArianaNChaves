using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate;

    private float _timeToShoot = 0;
    private bool _canShoot = true;

    private void Update()
    {
        _timeToShoot += Time.deltaTime;
        
        ValidateShoot();
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canShoot)
        {
            Shoot();
        }
    }

    private void ValidateShoot()
    {
        if (_timeToShoot >= fireRate)
        {
            _canShoot = true;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        ResetShootTime();
    }

    private void ResetShootTime()
    {
        _canShoot = false;
        _timeToShoot = 0;
    }
}
