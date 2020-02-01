using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : Controllable
{
    [SerializeField] CharacterController characterController = null;
    public override void Control()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        characterController.Move(transform.right * horizontal);
        characterController.Move(transform.forward * vertical);
    }
}
