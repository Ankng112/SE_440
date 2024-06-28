using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveAndScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(Vector3.one * 3,2f).SetLoops(5,LoopType.Restart).SetEase(Ease.Linear).OnComplete(()=>
        {
            Debug.Log("Move Done");
        });

    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
