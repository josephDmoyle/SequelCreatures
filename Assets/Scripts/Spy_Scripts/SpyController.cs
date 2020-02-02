using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyController : Controllable
{
    [SerializeField] CharacterController characterController = null;
    Rigidbody rb;
    public float speed = 10.0f;
    private GameObject player;
    private Vector3 raycastDirect = Vector3.right;
    public bool defeated = false;
    public Animator animator;
    Vector3 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator.GetComponent<Animator>();
    }
    void Update()
    {
        if (lastPosition != gameObject.transform.position)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
        }
        lastPosition = gameObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sight")
        {
            //Shoot the player
            Vector3 target = collision.transform.position;
            //End Spy mode
            Destroy(player);
            // Timer for new Spy
        }
        if (collision.gameObject.tag == "Enemies")
        {
            //Melee the Player

            //End Spy Mode
            Destroy(player);
            //Timer for new Spy

        }
    }

    public override void Control()
    {
        if (!defeated)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                raycastDirect = (transform.position + (new Vector3(horizontal, 0, vertical)).normalized);
            }

            transform.LookAt(raycastDirect);

            characterController.Move(transform.forward * Time.fixedDeltaTime * speed * Mathf.Min(1.0f, (Mathf.Abs(horizontal) + Mathf.Abs(vertical))));
        }
    }
}
