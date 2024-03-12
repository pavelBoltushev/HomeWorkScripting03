using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Text _healthValueText;
    [SerializeField] private float _changeSpeed;
    
    private float _displayedValue;
    private bool _isChangeDisplayedValueInProgress;    

    private void Start()
    {
        _healthBar.minValue = 0;
        _healthBar.maxValue = _health.MaxValue;        
        SetDisplayedValue(_health.Value);             
    }

    private void OnEnable()
    {
        _health.ValueChanged += StartChangeDisplayedValue;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= StartChangeDisplayedValue;
    }

    public void StartChangeDisplayedValue(int changeValue)
    {
        if (_isChangeDisplayedValueInProgress == false)        
            StartCoroutine(ChangeDisplayedValue());        
    }

    private IEnumerator ChangeDisplayedValue()
    {
        _isChangeDisplayedValueInProgress = true;

        while (_displayedValue != _health.Value)
        {
            SetDisplayedValue(Mathf.MoveTowards(_displayedValue, _health.Value, _changeSpeed * Time.deltaTime));
            yield return null;
        }

        _isChangeDisplayedValueInProgress = false;
    }

    private void SetDisplayedValue(float value)
    {
        _displayedValue = value;
        _healthBar.value = _displayedValue;
        _healthValueText.text = ((int)_displayedValue).ToString();
    }    
}
