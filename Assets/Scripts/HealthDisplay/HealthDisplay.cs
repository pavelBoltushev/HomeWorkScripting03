using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.ValueChanged += SetDisplayedValue;
    }

    private void OnDisable()
    {
        Health.ValueChanged -= SetDisplayedValue;
    }

    protected abstract void SetDisplayedValue(float changeValue);    
}
