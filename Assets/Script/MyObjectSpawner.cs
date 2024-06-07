using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjectSpawner : ObjectSpawner

{
    [Header ("Custom Spawn")]
    [SerializeField]private GameObject objectSpawn;

    private GameObject _spawned;

    protected override bool CustomSpawnGameObject(Vector3 spawnPoint,Vector3 spawnNormal);
    {
        if (_spawned != null)
        return true;
    }
    _spawned = Instantiate(objectSpawn);
    _spawned.transform.position = spawnPoint;
    return true;
}
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}