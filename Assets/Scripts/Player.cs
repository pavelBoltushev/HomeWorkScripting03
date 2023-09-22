using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private const int ForwardDirection = 1;
    private const int ReverseDirection = -1;
    private const string IsForwardWalk = "IsForwardWalk";
    private const string IsReverseWalk = "IsReverseWalk";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    
    private Animator _animator;
    private Rigidbody2D _rigidbody;    
    private bool _canJump = true;

    private void Awake()
    {        
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();        
    }    

    private void Update()
    {
        ProcessInput();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.TryGetComponent<TileMap>(out var tileMap))
        {
            _canJump = true;            
        }   
        
        if (collision.TryGetComponent<Enemy>(out var enemy))
        {
            Die();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        if (collision.TryGetComponent<TileMap>(out var tileMap))
        {
            _canJump = false;            
        }            
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool(IsForwardWalk, true);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool(IsForwardWalk, false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(ForwardDirection);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetBool(IsReverseWalk, true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool(IsReverseWalk, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Move(ReverseDirection);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _canJump)
        {
            Jump();
        }
    }

    private void Move(int direction)
    {
        float xPosition = transform.position.x;
        xPosition += _speed * direction * Time.deltaTime;
        transform.position = new Vector2(xPosition, transform.position.y);
    }   
    
    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void Die()
    {        
        Destroy(gameObject);
    }
}
