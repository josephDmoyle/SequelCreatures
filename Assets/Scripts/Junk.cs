﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        //if (collision.gameObject.GetComponent<Junk>() != null)
        //{
        //GC.materials += 10;
        //}
        Destroy(transform.parent.gameObject);
    }
}
