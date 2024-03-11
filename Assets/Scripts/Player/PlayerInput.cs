using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action DKeyDown;
    public event Action DKeyUp;
    public event Action DKeyHold;
    public event Action AKeyDown;
    public event Action AKeyUp;
    public event Action AKeyHold;
    public event Action SpaceKeyDown;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            DKeyDown?.Invoke();

        if (Input.GetKeyUp(KeyCode.D))
            DKeyUp?.Invoke();

        if (Input.GetKey(KeyCode.D))
            DKeyHold?.Invoke();

        if (Input.GetKeyDown(KeyCode.A))
            AKeyDown?.Invoke();

        if (Input.GetKeyUp(KeyCode.A))
            AKeyUp?.Invoke();

        if (Input.GetKey(KeyCode.A))
            AKeyHold?.Invoke();

        if (Input.GetKeyDown(KeyCode.Space))
            SpaceKeyDown?.Invoke();
    }
}
