using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    
    
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private PlayerShoot _playerShoot;
    private bool _isAttacking;
    
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerShoot = GetComponent<PlayerShoot>();
    }
    
    private void Update()
    {
        SetRunAnimation();
        SetJumpAnimation();
        SetAttackingAnimation();

    }

    private void SetRunAnimation()
    {
        _animator.SetFloat("RunSpeed", Mathf.Abs(_rigidbody2D.velocity.x));
    }

    private void SetJumpAnimation()
    {
        _animator.SetFloat("JumpSpeed",Mathf.Abs(_rigidbody2D.velocity.y));
    }

    private void SetAttackingAnimation()
    {
        _isAttacking = _playerShoot.GetIsAttacking();

        _animator.SetBool("IsAttacking", _isAttacking);
     

    }
}
