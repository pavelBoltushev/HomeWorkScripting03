using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
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

    public void OnHealthValueChanged(float changeValue)
    {
        if (changeValue < 0)
            _animator.SetTrigger(Damaged);

        if (changeValue > 0)
            _animator.SetTrigger(Healed);
    }       
}
