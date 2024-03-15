using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{       
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _pursuitContinueTime;
       
    private SpriteRenderer _renderer;
    private int _currentPatrolPointIndex = 0;
    private Vector2 _detectionDirection = Vector2.right;
    private float _pursuitTimer;
    private Transform _pursuitTarget;

    private void Awake()    {
        
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _pursuitTimer -= Time.deltaTime;

        if (TryDetectPlayer(out Transform player))
        {
            _pursuitTarget = player;
            _pursuitTimer = _pursuitContinueTime;        
        }       

        if (_pursuitTimer > 0)
            MoveTo(_pursuitTarget);
        else
            Patrol();        
    }

    private bool TryDetectPlayer(out Transform playerTransform)
    {       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _detectionDirection);

        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Player player))
        {
            playerTransform = hit.transform;
            return true;
        }
        else
        {
            playerTransform = null;
            return false;
        }
    }

    private void Patrol()
    {
        Transform currentPatrolPoint = _patrolPoints[_currentPatrolPointIndex];
        MoveTo(currentPatrolPoint);

        if (transform.position.x == currentPatrolPoint.position.x)
            _currentPatrolPointIndex = ++_currentPatrolPointIndex % _patrolPoints.Length;        
    }

    private void MoveTo(Transform targetPoint)
    {
        TurnTo(targetPoint);
        float xPosition = transform.position.x;
        xPosition = Mathf.MoveTowards(xPosition, targetPoint.position.x, _speed * Time.deltaTime);
        transform.position = new Vector2(xPosition, transform.position.y);
    }

    private void TurnTo(Transform targetPoint)
    {
        if (targetPoint.position.x > transform.position.x)
        {
            _detectionDirection = Vector2.right;            
            _renderer.flipX = false;
        }
        else
        {
            _detectionDirection = Vector2.left;            
            _renderer.flipX = true;
        }
    }    
}
