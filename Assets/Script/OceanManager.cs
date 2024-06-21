using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : SingleTon<OceanManager>
{
    [SerializeField] private GameObject ocean;
    [SerializeField] private float warePower = 2f;

    private Material _oceanMat;
    private Texture2D _oceanTex;

    private void Start()  
    {
        SetValue();
    }
    private void SetValue()
    {
        _oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        _oceanTex = (Texture2D)_oceanMat .GetTexture(name:"_mainTex");
    }
    private void OnValidate() 
    {
        if(! Application.isPlaying) return;
        if (ocean != null)
        {
            SetValue();
        }
        _oceanMat.SetFloat("_wavePower",warePower);
    }
    public float GetWareHight(Vector3 point)
    {
        float wareHight = _oceanTex.GetPixelBilinear(point.x,point.z).g * warePower;
        return wareHight; 
    }
}
