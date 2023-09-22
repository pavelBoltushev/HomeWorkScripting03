using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Apple : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            Destroy(gameObject);
        }
    }
}
