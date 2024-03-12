using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    private int _value;

    public event Action<int> ValueChanged;    

    public int MaxValue => _maxValue;
    public int Value => _value;

    protected void Awake()
    {
        _value = _maxValue;
    }

    public virtual void TakeDamage(int damage)
    {
        if (damage < 0)
            damage = 0;

        _value -= damage;
        ValueChanged?.Invoke(-damage);        

        if (_value <= 0)
            Die();
    }

    public virtual void TakeHeal(int heal)
    {
        if (heal < 0)
            heal = 0;

        _value += heal;
        ValueChanged?.Invoke(heal);        

        if (_value > _maxValue)
            _value = _maxValue;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
