using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : Controllable
{
    [SerializeField] private List<GameObject> barriers = new List<GameObject>();
    [SerializeField] private bool isDebug = true;
    [SerializeField] private float buildCooldown = .5f;
    [SerializeField] CharacterController characterController = null;
    [SerializeField] GameObject trapPrefab;

    private Vector3 raycastDirect = Vector3.right;
    private bool onCooldown = false;

    int barrierSelected = 0;

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

        if (Input.GetButton("Barrier"))
        {
            if (!onCooldown)
            {
                Invoke("Build", buildCooldown);
                onCooldown = true;
            }
        }

        if (Input.GetButtonDown("Trap"))
        {
            Instantiate(trapPrefab, transform.position, Quaternion.identity);
        }

        DrawDebug();
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
        //On interact, raycast to first object in facing direction
        Vector3 facingDirection = transform.TransformDirection(raycastDirect) * 3;
        int interactableLayerMask = LayerMask.GetMask("Interactable");
        //RaycastHit hit = Physics.Raycast(transform.position, facingDirection, 3, interactableLayerMask);
        RaycastHit hit;
        Physics.Raycast(transform.position, facingDirection, out hit, 3, interactableLayerMask);

        if (hit.collider)
        {
            //If an object is hit, check if it's interactable. Should be if it's on that layer
            IInteractable interactable = hit.transform.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }

        }
        onCooldown = false;
    }

    private void DrawDebug()
    {
        if (isDebug)
        {
            Vector3 rayDir = transform.TransformDirection(raycastDirect) * 3;
            Debug.DrawRay(transform.position, rayDir, Color.red);
        }
    }
}
