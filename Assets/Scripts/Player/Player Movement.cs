using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private SOPlayer playerData;
    [SerializeField] private LayerMask groundLayer; 
    [SerializeField] private Transform groundCheck;
    [SerializeField, Range(0.1f, 1f)] private float rayLength = 0.5f;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded;
    private bool _facingRight = true;
    private float _horizontalMovement;
    
    private float _jumpForce;
    private float _movementSpeed;
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
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, rayLength, groundLayer);
        _isGrounded = hit.collider != null;
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
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * rayLength);
    }
}