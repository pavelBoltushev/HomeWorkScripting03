using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VampirismAura : MonoBehaviour
{
    [SerializeField] private float _activationDuration;
    [SerializeField] private float _healthDrainPerSecond;
    [SerializeField] private Icon _icon;
    [SerializeField] private Health _hostHealth;

    private List<Health> _targets;
    private bool _isCoroutineInProgress;

    private void Awake()
    {        
        _targets = new List<Health>();
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            _targets.Add(health);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health))
        {
            _targets.Remove(health);
        }
    }

    public void Activate()
    {
        if (_isCoroutineInProgress == false)
            StartCoroutine(DrainHealth());
    }

    private IEnumerator DrainHealth()
    {
        _isCoroutineInProgress = true;
        _icon.On();
        float timer = _activationDuration;

        while (timer > 0)
        {
            float healthDrainAmount = _healthDrainPerSecond * Time.deltaTime;
            Health nearestTarget = _targets.OrderBy(target => Vector2.Distance(transform.position, target.transform.position)).FirstOrDefault();

            if (nearestTarget != null)
            {
                nearestTarget.TakeDamage(healthDrainAmount);
                _hostHealth.TakeHeal(healthDrainAmount);
            }

            timer -= Time.deltaTime;
            yield return null;
        }

        _icon.Off();
        _isCoroutineInProgress = false;
    }
}
