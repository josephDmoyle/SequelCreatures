using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Shooter : Grunt
{
    [SerializeField] Transform shootPosition = null;


    private void Start()
    {
        beginSeeEvent.AddListener(BeginSee);
        endSeeEvent.AddListener(EndSee);
    }

    void BeginSee(GameObject iGameObject)
    {

    }

    void EndSee(GameObject iGameObject)
    {

    }
}
