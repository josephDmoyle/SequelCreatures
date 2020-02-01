using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    void OnTriggerEnter(Collider collision)
    {
        Health.healths[collision.transform.root.gameObject].Damage(1);
    }
}
