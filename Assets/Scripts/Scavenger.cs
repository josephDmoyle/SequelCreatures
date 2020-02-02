using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scavenger : Controllable
{
    private float horizontal = 0;
    private float vertical = 0;

    [SerializeField] private float speed = 0.3f;

    [SerializeField] private JunkyardController JC = null;

    [SerializeField] CharacterController characterController = null;
    public override void Control()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            horizontal = 1;
            vertical = 0;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            horizontal = -1;
            vertical = 0;
        }
        else if(Input.GetAxis("Vertical") > 0)
        {
            vertical = 1;
            horizontal = 0;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            vertical = -1;
            horizontal = 0;
        }

        //characterController.Move(transform.right * horizontal);
        characterController.Move(transform.forward * speed);

        transform.LookAt(new Vector3(transform.position.x + horizontal, transform.position.y, transform.position.z + vertical));
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.GetComponent<Junk>() != null)
        {
            JC.materials += 10;
        }
        if (collision.gameObject.GetComponent<Trap>() != null)
        {
            JC.TookDamage();
        }
    }

    
}
