using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private KeyCode _rightMoveKey = KeyCode.D;
    private KeyCode _leftMoveKey = KeyCode.A;
    private KeyCode _jumpKey = KeyCode.Space;
    private KeyCode _vampirismKey = KeyCode.V;

    public event Action RightMoveKeyPressed;
    public event Action RightMoveKeyReleased;
    public event Action RightMoveKeyHold;
    public event Action LeftMoveKeyPressed;
    public event Action LeftMoveKeyReleased;
    public event Action LeftMoveKeyHold;
    public event Action JumpKeyPressed;
    public event Action VampirismKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(_rightMoveKey))
            RightMoveKeyPressed?.Invoke();

        if (Input.GetKeyUp(_rightMoveKey))
            RightMoveKeyReleased?.Invoke();

        if (Input.GetKey(_rightMoveKey))
            RightMoveKeyHold?.Invoke();

        if (Input.GetKeyDown(_leftMoveKey))
            LeftMoveKeyPressed?.Invoke();

        if (Input.GetKeyUp(_leftMoveKey))
            LeftMoveKeyReleased?.Invoke();

        if (Input.GetKey(_leftMoveKey))
            LeftMoveKeyHold?.Invoke();

        if (Input.GetKeyDown(_jumpKey))
            JumpKeyPressed?.Invoke();

        if (Input.GetKeyDown(_vampirismKey))
            VampirismKeyPressed?.Invoke();
    }
}
