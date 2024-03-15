using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Icon : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void On()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1f);
    }

    public void Off()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0f);
    }
}
