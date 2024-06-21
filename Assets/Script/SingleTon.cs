using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
{
   private static T _instance;
   public static T Instance => _instance;
   [SerializeField] private bool isDontDestroyOnload;

    private void Awake() 
    {
        Debug.Log("Hello");
        if (_instance == null)
        {
            _instance = (T)this;
        }
        else
        {
            Destroy(gameObject);
        }
        if (isDontDestroyOnload)
        {
            DontDestroyOnLoad(this);
        }
   }
}
