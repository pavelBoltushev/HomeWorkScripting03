using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private const string IsForwardWalk = "IsForwardWalk";
    private const string IsReverseWalk = "IsReverseWalk";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ProcessInput();
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

        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetBool(IsReverseWalk, true);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            _animator.SetBool(IsReverseWalk, false);
        }
    }
}
