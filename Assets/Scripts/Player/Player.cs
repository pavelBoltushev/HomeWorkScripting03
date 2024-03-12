using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimation))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    private PlayerInput _input;
    private PlayerMover _mover;
    private PlayerAnimation _animation;
    private Health _health;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _mover = GetComponent<PlayerMover>();
        _animation = GetComponent<PlayerAnimation>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _input.RightMoveKeyHold += _mover.MoveForward;
        _input.LeftMoveKeyHold += _mover.MoveReverse;
        _input.JumpKeyPressed += _mover.Jump;
        _input.RightMoveKeyPressed += _animation.WalkForward;
        _input.LeftMoveKeyPressed += _animation.WalkReverse;
        _input.RightMoveKeyReleased += _animation.Stand;
        _input.LeftMoveKeyReleased += _animation.Stand;
        _health.ValueChanged += _animation.OnHealthValueChanged;        
    }

    private void OnDisable()
    {
        _input.RightMoveKeyHold -= _mover.MoveForward;
        _input.LeftMoveKeyHold -= _mover.MoveReverse;
        _input.JumpKeyPressed -= _mover.Jump;
        _input.RightMoveKeyPressed -= _animation.WalkForward;
        _input.LeftMoveKeyPressed -= _animation.WalkReverse;
        _input.RightMoveKeyReleased -= _animation.Stand;
        _input.LeftMoveKeyReleased -= _animation.Stand;
        _health.ValueChanged -= _animation.OnHealthValueChanged;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Medipack mediPack))
        {
            _health.TakeHeal(mediPack.HealingValue);
            Destroy(mediPack.gameObject);
        }
    }
}
