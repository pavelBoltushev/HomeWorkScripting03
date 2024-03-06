using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerMover : MonoBehaviour
{
    private const int ForwardDirection = 1;
    private const int ReverseDirection = -1;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _damagePullBackForce;

    private Rigidbody2D _rigidbody;
    private PlayerHealth _playerHealth;
    private bool _canJump = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        ProcessInput();
    }

    public void PullBackFrom(Transform enemy)
    {
        Vector2 direction = (transform.position - enemy.position).normalized;
        _rigidbody.velocity = new Vector2(0, 0);
        _rigidbody.AddForce(direction * _damagePullBackForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TileMap>(out var tileMap))
        {
            _canJump = true;
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
        if (Input.GetKey(KeyCode.D))
        {
            Move(ForwardDirection);
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
}
