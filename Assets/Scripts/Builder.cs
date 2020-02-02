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

    [SerializeField] private JunkyardController JC = null;

    private Vector3 raycastDirect = Vector3.right;
    private bool onCooldown = false;

    private bool building = false;

    int barrierSelected = 0;

    public override void Control()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            raycastDirect = (transform.position + (new Vector3(horizontal, 0, vertical)).normalized);
        }

        transform.LookAt(raycastDirect);

        characterController.Move(transform.forward * Mathf.Min(1.0f, (Mathf.Abs(horizontal) + Mathf.Abs(vertical))));

        DrawDebug();

        if (Input.GetKeyDown(KeyCode.Space))
            building = true;
        if(Input.GetKeyUp(KeyCode.Space))
            building = false;

        if (Input.GetButtonDown("BarrierChange"))
        {
            SelectedBarrier(barrierSelected + 1);
        }

        if (building)
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
        int interactableLayerMask = LayerMask.GetMask("Interactable");
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 10, interactableLayerMask);

        if (hit.collider)
        {
            //If an object is hit, check if it's interactable. Should be if it's on that layer
            IInteractable interactable = hit.transform.gameObject.GetComponent<IInteractable>();
            if (interactable != null && !interactable.CheckFinished())
            {
                if (JC.materials >= 2)
                {
                    interactable.Interact();
                    JC.materials -= 2;
                }
            }

        }
        onCooldown = false;
    }

    private void DrawDebug()
    {
        if (isDebug)
        {
            //Vector3 rayDir = transform.TransformDirection(transform.forward) * 10;
            Debug.DrawRay(transform.position, transform.forward*10, Color.red, 2.0f, false);
        }
    }
}
