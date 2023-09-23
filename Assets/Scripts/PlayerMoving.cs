using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoving : MonoBehaviour
{
    private const int ForwardDirection = 1;
    private const int ReverseDirection = -1;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private bool _canJump = true;

    private void Awake()
    {
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

        if (collision.TryGetComponent<Apple>(out var apple))
        {
            Destroy(collision.gameObject);
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

    private void Die()
    {
        Destroy(gameObject);
    }
}
