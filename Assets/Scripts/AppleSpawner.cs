using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Apple _apple;
    [SerializeField] private float _spawnPeriodicity;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_spawnPeriodicity);

        while (true)
        {
            int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Length);
            Instantiate(_apple, _spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
            yield return wait;            
        }        
    }
}
