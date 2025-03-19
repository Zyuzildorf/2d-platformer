using System;
using UnityEngine;


public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private float _moveInput;

    private void Awake()
    {
        if (TryGetComponent(out Rigidbody2D rigidbody2D))
        {
            _rigidbody = rigidbody2D;
        }
        else
        {
            Debug.LogError("Can't find rigidbody component;");
        }
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _moveInput = Input.GetAxis("Horizontal");

        _rigidbody.velocity = new Vector2(_moveInput * _moveSpeed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            Debug.Log("Spacebar pressed.");

            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isGrounded = true;
        Debug.Log(_isGrounded);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isGrounded = false;

        Debug.Log(_isGrounded);
    }
}