using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private const int ForwardDirection = 1;
    private const int ReverseDirection = -1;
    private const string IsForwardWalk = "IsForwardWalk";
    private const string IsReverseWalk = "IsReverseWalk";

    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _patrolPoints;

    private Animator _animator;    
    private int _currentPatrolPointIndex = 0;

    private void Awake()
    {        
        _animator = GetComponent<Animator>();        
    }   

    private void Update()
    {
        Patrol();
    }   
    
    private void Patrol()
    {
        Transform currentPatrolPoint = _patrolPoints[_currentPatrolPointIndex];
        int currentDirection = DetermineDirection(currentPatrolPoint);
        SetAnimation(currentDirection);
        Move(currentDirection);
        bool isArrived = (currentDirection == ForwardDirection && transform.position.x >= currentPatrolPoint.position.x) ||
                         (currentDirection == ReverseDirection && transform.position.x <= currentPatrolPoint.position.x);

        if (isArrived)
        {
            SetNextPatrolPointIndex();
        }
    }

    private void Move(int direction)
    {
        float xPosition = transform.position.x;
        xPosition += _speed * direction * Time.deltaTime;
        transform.position = new Vector2(xPosition, transform.position.y);
    }

    private int DetermineDirection(Transform targetPoint)
    {
        if (targetPoint.position.x > transform.position.x)
        {
            return ForwardDirection;
        }
        else
        {
            return ReverseDirection;
        }
    }

    private void SetAnimation(int currentDirection)
    {
        if (currentDirection == ForwardDirection)
        {
            _animator.SetBool(IsForwardWalk, true);
            _animator.SetBool(IsReverseWalk, false);
        }

        if (currentDirection == ReverseDirection)
        {
            _animator.SetBool(IsForwardWalk, false);
            _animator.SetBool(IsReverseWalk, true);
        }
    }

    private void SetNextPatrolPointIndex()
    {
        _currentPatrolPointIndex++;

        if (_currentPatrolPointIndex == _patrolPoints.Length)
            _currentPatrolPointIndex = 0;
    }
}
