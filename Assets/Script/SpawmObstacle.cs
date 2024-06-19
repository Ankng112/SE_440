using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; 

public class SpawmObstacle : MonoBehaviour
{
    [ SerializeField] private float spawmInterval = 1f;
    [ SerializeField] private float radius = 20f;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawmInterval)
        {
            _timer = 0;
            Spawn ();
        }
    }
    private void Spawn ()
    {
        if (!ObjectPool.Instance.CanSpawm())return;
        var obj = ObjectPool.Instance.PickOne(transform);
        var pos= Random.insideUnitSphere * radius;
        pos.y = Mathf.Abs(pos.y);
        obj.transform.position = pos;
        obj.SetActive(true);
    }
    
}
