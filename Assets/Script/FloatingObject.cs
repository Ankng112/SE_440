using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatingObject : MonoBehaviour
{
    [SerializeField] private float underWaterDrag;
    [SerializeField] private float underWaterAngularDrag;
    [SerializeField] private float airDrag;
    [SerializeField] private float airAngularDrag;
    [SerializeField] private float waterPower;
    [SerializeField] private Transform[] floatPoints;


    private Rigidbody _rb;
    private bool _isUnderWater;
    private void Start() 
    {
        _rb = GetComponent<Rigidbody>();    
    }
    private void Update() 
    {
        int pointUnderWaterCount = 0;
        foreach (var point in floatPoints)
        {
            var diff = point.position.y - OceanManager.Instance.GetWareHight(point.position);
            if (diff < 0)
            {
                _rb.AddForceAtPosition(
                    Vector3.up * waterPower * Mathf.Abs(diff),
                    point.position,
                    ForceMode.Acceleration);
                    pointUnderWaterCount++;
                if (!_isUnderWater)
                {
                    _isUnderWater = true;
                    SetStage(true);
                }
            }
        }
        
        if(_isUnderWater && pointUnderWaterCount == 0)
        {
            _isUnderWater = false;
            SetStage(underWater:false);
        }
    }
    private void SetStage (bool underWater)
    {
        if (underWater)
        {
            _rb.drag = underWaterDrag;
            _rb.angularDrag = underWaterAngularDrag;
        }
        else
        {
            _rb.drag = airDrag;
            _rb.angularDrag = airAngularDrag;
        }
    }

}
