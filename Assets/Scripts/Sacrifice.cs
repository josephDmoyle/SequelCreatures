using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : MonoBehaviour
{
    public GameObject sacrifice;

    public DieScript other;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startSacrifice();
        }
    }

    void startSacrifice()
    {
        //this object performs pushing animation

        other.Die();

    }
}
