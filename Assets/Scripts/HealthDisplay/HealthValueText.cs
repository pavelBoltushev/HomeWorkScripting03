using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HealthValueText : HealthDisplay
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = $"{(int)Health.Value} / {Health.MaxValue}";
    }    

    protected override void SetDisplayedValue(float changeValue)
    {
        _text.text = $"{(int)Health.Value} / {Health.MaxValue}";       
    }
}
