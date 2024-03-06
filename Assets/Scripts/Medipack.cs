using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medipack : MonoBehaviour
{
    [SerializeField] private int _healingValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            playerHealth.TakeHeal(_healingValue);
            Destroy(gameObject);
        }
    }
}
