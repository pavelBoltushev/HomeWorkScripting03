using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMover : MonoBehaviour
{
    private const string IsForwardWalk = "IsForwardWalk";
    private const string IsReverseWalk = "IsReverseWalk";

    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _pursuitContinueTime;

    private Animator _animator;
    private int _currentPatrolPointIndex = 0;
    private Vector2 _detectionDirection = Vector2.right;
    private float _pursuitTimer;
    private Transform _pursuitTarget;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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

    private bool TryDetectPlayer(out Transform player)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _detectionDirection);

        if (hit.collider != null && hit.collider.gameObject.TryGetComponent<PlayerHealth>(out var component))
        {
            player = hit.transform;
            return true;
        }
        else
        {
            player = null;
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
            _animator.SetBool(IsForwardWalk, true);
            _animator.SetBool(IsReverseWalk, false);
        }
        else
        {
            _detectionDirection = Vector2.left;
            _animator.SetBool(IsForwardWalk, false);
            _animator.SetBool(IsReverseWalk, true);
        }
    }    
}
