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
        _input.DKeyHold += _mover.MoveForward;
        _input.AKeyHold += _mover.MoveReverse;
        _input.SpaceKeyDown += _mover.Jump;
        _input.DKeyDown += _animation.WalkForward;
        _input.AKeyDown += _animation.WalkReverse;
        _input.DKeyUp += _animation.Stand;
        _input.AKeyUp += _animation.Stand;
        _health.Damaged += _animation.OnDamaged;
        _health.Healed += _animation.OnHealed;
    }

    private void OnDisable()
    {
        _input.DKeyHold -= _mover.MoveForward;
        _input.AKeyHold -= _mover.MoveReverse;
        _input.SpaceKeyDown -= _mover.Jump;
        _input.DKeyDown -= _animation.WalkForward;
        _input.AKeyDown -= _animation.WalkReverse;
        _input.DKeyUp -= _animation.Stand;
        _input.AKeyUp -= _animation.Stand;
        _health.Damaged -= _animation.OnDamaged;
        _health.Healed -= _animation.OnHealed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Medipack>(out var mediPack))
        {
            _health.TakeHeal(mediPack.HealingValue);
            Destroy(mediPack.gameObject);
        }
    }
}
