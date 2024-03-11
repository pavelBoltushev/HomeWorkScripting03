using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    private const string IsWalk = "IsWalk";
    private const string Damaged = "Damaged";
    private const string Healed = "Healed";

    private Animator _animator;
    private SpriteRenderer _renderer;    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();        
    }     

    public void WalkForward()
    {
        _renderer.flipX = false;
        _animator.SetBool(IsWalk, true);
    }

    public void WalkReverse()
    {
        _renderer.flipX = true;
        _animator.SetBool(IsWalk, true);
    }

    public void Stand()
    {
        _animator.SetBool(IsWalk, false);
    }

    public void OnDamaged()
    {
        _animator.SetTrigger(Damaged);
    }

    public void OnHealed()
    {
        _animator.SetTrigger(Healed);
    }    
}
