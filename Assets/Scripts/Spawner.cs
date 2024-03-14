using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Spawned _template;
    [SerializeField] private float _spawnPeriodicity;

    private Spawned[] _spawnedReferencies;

    private void Start()
    {
        _spawnedReferencies = new Spawned[_spawnPoints.Length];
        StartCoroutine(Spawn());
    }      

    public IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_spawnPeriodicity);

        while (true)
        {
            int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Length);

            if (_spawnedReferencies[randomSpawnPointIndex] == null)
            {                
                Spawned spawned = Instantiate(_template, _spawnPoints[randomSpawnPointIndex].position, Quaternion.identity);
                _spawnedReferencies[randomSpawnPointIndex] = spawned;
                spawned.SetSpawner(this);
            }            

            yield return wait;            
        }        
    }

    public void RemoveSpawnedReference(Spawned spawnedToRemove)
    {
        for (int i = 0; i < _spawnedReferencies.Length; i++)
        {
            if (_spawnedReferencies[i] == spawnedToRemove)            
                _spawnedReferencies[i] = null;            
        }
    }
}
