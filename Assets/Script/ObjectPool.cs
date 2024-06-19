using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instansce;
    public static ObjectPool Instance 
    {
        get
        {
            if (_instansce == null)
            {
                _instansce = FindObjectOfType<ObjectPool>();
            }
            return _instansce;
        }
    }
    private List<GameObject> _poolList = new List <GameObject> ();// Danh sach chua cac thanh phan
    private Stack<GameObject> _poolStack= new Stack <GameObject> ();// Xep chong tao noi luu tru Pool
    private Queue<GameObject> _poolQueue = new Queue <GameObject> ();// Hang doi lay ra la mat luon trong ds

    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10 ;


    private void Start()
    {
     for (int i = 0;i < poolSize; i++)
     {
        var obj = Instantiate (prefab, transform);obj.SetActive(false);
        obj.SetActive(false);
        obj.name = prefab.name + $" ({i}) ";
        _poolQueue.Enqueue(obj);
     }   
    }
    public bool CanSpawm()
    {
        return _poolQueue.Count > 0;
    }
    public GameObject PickOne(Transform parent)
    {
        var obj = _poolQueue.Dequeue ();
        obj.transform.SetParent(parent);
        return obj;
    }
    public void ReturnOne (GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        _poolQueue.Enqueue(obj);
    }
    void Update()
    {
        
    }
}
