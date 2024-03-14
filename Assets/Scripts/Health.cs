using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    private float _value;

    public event Action<float> ValueChanged;    

    public float MaxValue => _maxValue;
    public float Value => _value;

    protected void Awake()
    {
        _value = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            damage = 0;

        _value -= damage;
        _value = Mathf.Clamp(_value, 0, _maxValue);
        ValueChanged?.Invoke(-damage);        

        if (_value == 0)
            Die();
    }

    public void TakeHeal(float heal)
    {
        if (heal < 0)
            heal = 0;

        _value += heal;
        _value = Mathf.Clamp(_value, 0, _maxValue);
        ValueChanged?.Invoke(heal);        
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
