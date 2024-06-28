using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Dai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MoveGameObject(()=> 
        {
            Debug.Log("Callback");
        });
        {
            Debug.Log("Start call count down");
            StartCoroutine(CountDown());
            Debug.Log("End count down");
        }
        MultiThread02();
    }
    private async void MultiThread02()
    {
        List<UniTask> tasks = new List<UniTask>();
        tasks.Add(TaskA("Move Objec",2000));
        tasks.Add(TaskA("Scale Object",4000));
        await UniTask.WhenAll(tasks);
        Debug.Log("Completed tasks");
    }
    private async UniTask TaskA (string log,int delay)
    {
        Debug.Log($"Task Start {log}");
        await UniTask.Delay(delay);
        Debug.Log($"Task Done {log}");
    }
    private IEnumerator CountDown()
    {
        Debug.Log("Start Count Down");
        int countTime = 3;
        for (int i=0; i< countTime;i++)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("End count down");
    }
    private void MoveGameObject (Action callback)
    {
        Debug.Log("Move Game Object completed");
        callback?.Invoke();
    }
}
