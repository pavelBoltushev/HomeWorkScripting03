using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawned : MonoBehaviour
{
    private Spawner _spawner;

    private void OnDestroy()
    {
        _spawner.RemoveSpawnedReference(this);
    }

    public void SetSpawner(Spawner spawner)
    {
        _spawner = spawner;
    }
}
