using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SOPlayer playerData;
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float sphereRadius;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private bool _facingRight = true;
    private float _horizontalMovement;
    private float _jumpForce;
    private float _movementSpeed;

    private const float NormalSpeed = 1.0f;
    private const float AirSpeedModifier = 0.5f;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _jumpForce = playerData.JumpForce;
        _movementSpeed = playerData.MovementSpeed;
    }

    private void FixedUpdate()
    {
        Movement();
        CheckGrounded(); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Jump();
        }
    }

    private void Movement()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _horizontalMovement *= _isGrounded ? NormalSpeed : AirSpeedModifier;
        
        if (_horizontalMovement > 0)
        {
            Flip();
        }
        else if (_horizontalMovement < 0)
        {
            Flip();
        }
        
        Vector2 speed = new Vector2(_horizontalMovement * (_movementSpeed), _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = speed;
    }

    private void Jump()
    {
        AudioManager.Instance.PlayEffect("Jump");
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGrounded()
    {
        Collider2D hit = Physics2D.OverlapCircle(groundCheck.position, sphereRadius, groundLayer);
        _isGrounded = hit != null;
    }

    private void Flip()
    {
        if((_horizontalMovement < 0 && _facingRight) || (_horizontalMovement > 0 && !_facingRight))
        {
            _facingRight = !_facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, sphereRadius);
    }
}
