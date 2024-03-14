using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class FlowingHealthBar : HealthBar
{    
    [SerializeField] private float _changeSpeed;
    
    private bool _isCoroutineInProgress;       

    protected override void SetDisplayedValue(float changeValue)
    {        
        if (_isCoroutineInProgress == false)
            StartCoroutine(ChangeDisplayedValue());
    }

    private IEnumerator ChangeDisplayedValue()
    {
        _isCoroutineInProgress = true;

        while (Bar.value != Health.Value / Health.MaxValue)
        {
            Bar.value = Mathf.MoveTowards(Bar.value, Health.Value / Health.MaxValue, _changeSpeed * Time.deltaTime);
            yield return null;
        }

        _isCoroutineInProgress = false;
    }    
}
