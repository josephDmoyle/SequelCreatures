using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacrifice : Controllable
{
    [SerializeField] CharacterController characterController = null;
    public GameObject sacrifice;

    public DieScript other;


    // Start is called before the first frame update
    void Start()
    {
    }

    void startSacrifice()
    {
        //this object performs pushing animation

        other.Die();

    }

    public override void Control()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            startSacrifice();
        }
    }
}
