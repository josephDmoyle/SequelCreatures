using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Shooter : Grunt
{
    [SerializeField] Transform shootPosition = null;

    protected override void OnTriggerEnter(Collider iOther)
    {
        if (!iOther.isTrigger)
            if (grublins.ContainsKey(iOther.gameObject))
                Debug.Log(transform.name + " sees: " + iOther.transform.name);
    }
}
