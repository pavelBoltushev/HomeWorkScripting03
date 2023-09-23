using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{    
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
        SetAnimation(currentPatrolPoint);
        Move(currentPatrolPoint);        
    }

    private void Move(Transform targetPoint)
    {        
        float xPosition = transform.position.x;
        xPosition = Mathf.MoveTowards(xPosition, targetPoint.position.x, _speed * Time.deltaTime);
        transform.position = new Vector2(xPosition, transform.position.y);

        if (xPosition == targetPoint.position.x)
        {
            SetNextPatrolPointIndex();
        }
    }    

    private void SetAnimation(Transform targetPoint)
    {
        if (targetPoint.position.x > transform.position.x)
        {
            _animator.SetBool(IsForwardWalk, true);
            _animator.SetBool(IsReverseWalk, false);
        }
        else
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
