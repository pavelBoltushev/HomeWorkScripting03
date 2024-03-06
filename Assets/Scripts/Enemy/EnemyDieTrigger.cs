using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieTrigger : MonoBehaviour
{
    [SerializeField] private Enemy host;

    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.TryGetComponent<PlayerMover>(out var component))
        {
            Destroy(host.gameObject);
            Destroy(gameObject);
        }        
    }
}
