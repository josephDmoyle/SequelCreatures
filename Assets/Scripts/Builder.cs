using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : Controllable
{
    [SerializeField] private List<GameObject> barriers = new List<GameObject>();

    int barrierSelected = 0;

    [SerializeField] CharacterController characterController = null;
    public override void Control()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        characterController.Move(transform.right * horizontal);
        characterController.Move(transform.forward * vertical);

        if (Input.GetButtonDown("BarrierChange"))
        {
            SelectedBarrier(barrierSelected + 1);
        }

        if (Input.GetButtonDown("Barrier"))
        {
            Build();
        }
    }

    void SelectedBarrier(int choice)
    {
        if(choice >= barriers.Count)
        {
            choice = 0;
        }
        barrierSelected = choice;
    }

    void Build()
    {
        Instantiate(barriers[barrierSelected], transform.position, Quaternion.identity);
    }
}
