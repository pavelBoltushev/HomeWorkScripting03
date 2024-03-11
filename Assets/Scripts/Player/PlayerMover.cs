using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
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
    
    public void Jump()
    {
        if (_canJump)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }    

    public void MoveForward()
    {
        Move(ForwardDirection);
    }

    public void MoveReverse()
    {
        Move(ReverseDirection);
    }

    private void Move(int direction)
    {        
        transform.Translate(new Vector2(_speed * direction * Time.deltaTime, 0));
    }
}
