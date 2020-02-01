﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPrefab : MonoBehaviour, IInteractable
{
    public Color Color1, Color2;
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private float Speed = 1f;
    private float Offset = 1f;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _propBlock = new MaterialPropertyBlock();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //_renderer.GetPropertyBlock(_propBlock);
        //_propBlock.SetColor("_Color", Color.Lerp(Color1, Color2, (Mathf.Sin(Time.time * Speed + Offset) + 1) / 2f));
        //Color currentColor = _propBlock.GetColor("_Color");
        //_renderer.SetPropertyBlock(_propBlock);
    }

    public void Interact()
    {
        Debug.Log("Building interaction");
        Color newColor = _propBlock.GetColor("_Color");
        newColor.a += .01f;
        Debug.Log("New Color:" + newColor);
        _propBlock.SetColor("_Color", newColor);
        Debug.Log("New Color:" + newColor);
        _renderer.SetPropertyBlock(_propBlock);
    }
}
