using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : HealthDisplay
{   
    protected Slider Bar;

    private void Start()
    {
        Bar = GetComponent<Slider>();
        Bar.value = Health.Value / Health.MaxValue;
    }    

    protected override void SetDisplayedValue(float changeValue)
    {
        Bar.value = Health.Value / Health.MaxValue;
    }
}
