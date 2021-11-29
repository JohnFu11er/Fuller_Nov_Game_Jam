using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce = 2f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Canvas _deathMessage;
    [SerializeField] private AudioSource _jumpSound;
    const float _groundRadius = .2f;
    private Rigidbody2D _rb;
    private float _horizontal;
    private float _Vertical;
    private bool _isGrounded = true;
    private float _move = 0f;
    private bool _isMovable = true;
    private bool _isFacingRight;
    private BoxCollider2D _boxCollider;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }


    void FixedUpdate()
    {   
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
        }
        else _isGrounded = false;

        GroundCheck();
        if (_isMovable) Move();
    }


    void Move()
    {
        _move = Input.GetAxis("Horizontal");
        Flip(); 
        transform.position += new Vector3(_move, 0, 0) * _speed * Time.deltaTime;
    }


    void Jump()
    {
        _isGrounded = false;
        _rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        _jumpSound.Play();
    }


    void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundRadius, _whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject && _rb.velocity.y < 0.1f)
            {
                // Debug.Log(colliders[i].gameObject.name);
                _isGrounded = true;
                // Debug.Log($"in collider checking: isgrounded: {_isGrounded}");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Hazard"))  Die();
    }

    void Flip()
    {
         if (_move < 0)
         {
             _isFacingRight = false;
             transform.localRotation = Quaternion.Euler(0, 180, 0);
         }
         else
         {
             _isFacingRight = true;
             transform.localRotation = Quaternion.Euler(0, 0, 0);
         }
    }

    void Die()
    {
        // Debug.Log("You Died");
        _deathMessage.gameObject.SetActive(true);
        _rb.velocity = Vector3.zero;
        _isMovable = false;
        _boxCollider.enabled = false;
        Jump();
    }
}