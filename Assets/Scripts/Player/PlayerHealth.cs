using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private Color _damageColor;
    [SerializeField] private Color _healingColor;

    private PlayerMover _playerMoving;
    private SpriteRenderer _renderer;
    private Color _initialColor;
    private int _value;


    private void Awake()
    {
        _value = _maxValue;
        _playerMoving = GetComponent<PlayerMover>();
        _renderer = GetComponent<SpriteRenderer>();
        _initialColor = _renderer.color;
    }    

    public void TakeDamage(Transform enemy, int damage)
    {
        if (damage < 0)
            damage = 0;

        _value -= damage;
        StartCoroutine(Blink(_damageColor));
        _playerMoving.PullBackFrom(enemy);

        if (_value <= 0)
            Die();
    }   
    
    public void TakeHeal(int heal)
    {
        if (heal < 0)
            heal = 0;       

        _value += heal;
        StartCoroutine(Blink(_healingColor));

        if (_value > _maxValue)
            _value = _maxValue;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator Blink(Color color)
    {
        for (int i = 0; i < 5; i++)
        {
            _renderer.color = color;
            yield return new WaitForSeconds(0.1f);
            _renderer.color = _initialColor;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
