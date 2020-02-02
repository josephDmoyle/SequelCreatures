using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPrefab : MonoBehaviour, IInteractable
{
    public int resourceNeed;
    public int resourcesSpent;
    public bool isFinished = false;
    private Renderer _renderer;
    [SerializeField] private MaterialPropertyBlock _propBlock;
    //[SerializeField] private Material finishMaterial;

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

    }

    public void Interact()
    {
        if (resourcesSpent < resourceNeed)
        {
            resourcesSpent += 1;
            Color newColor = _propBlock.GetColor("_Color");
            newColor.b = 255f;
            newColor.g = 255f;
            newColor.r = 255f;
            newColor.a = ((float)resourcesSpent / (float)resourceNeed);
            _propBlock.SetColor("_Color", newColor);
            _renderer.SetPropertyBlock(_propBlock);
        }
        else
        {
            isFinished = true;
            //_renderer.SetPropertyBlock(new MaterialPropertyBlock());
        }
    }

    public bool CheckFinished()
    {
        return isFinished;
    }
}
