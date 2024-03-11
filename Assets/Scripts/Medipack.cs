using UnityEngine;

public class Medipack : MonoBehaviour
{
    [SerializeField] private int _healingValue;

    public int HealingValue => _healingValue;
}
