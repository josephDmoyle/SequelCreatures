using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private void OnTriggerEnter(Collider iOther)
    {
        Debug.Log(gameObject.name + " sees: " + iOther.gameObject.name);
    }
}
