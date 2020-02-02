using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeOver : MonoBehaviour
{
    private BoxCollider col;

    void Awake()
    {
        col = GetComponent<BoxCollider>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                gameObject.tag = "TakeOver";
            }
            
        }
    }
}
