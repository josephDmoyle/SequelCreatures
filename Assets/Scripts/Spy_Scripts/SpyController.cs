using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyController : Controllable
{
    [SerializeField] SpriteBillboard sb;
    [SerializeField] CharacterController characterController = null;
    Rigidbody rb;
    public float speed = 10.0f;
    private GameObject player;
    private Vector3 raycastDirect = Vector3.right;
    public bool defeated = false;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sb.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        animator.GetComponent<Animator>();
        animator.SetBool("isIdle", true);
    }
    void Update()
    {
        
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
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Latch")
        {
            //Icon to attack appears
            sb.gameObject.SetActive(true);
            //If attack is pressed
            if (Input.GetKey(KeyCode.Space))
            {
                //Change enemies tag
                gameObject.tag = "TakeOver";
                sb.gameObject.SetActive(false);
            }
        }
    }

    public override void Control()
    {
        if (!defeated)
        {
            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    rb.velocity = transform.right * speed;
            //}
            //else if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    rb.velocity = -transform.right * speed;
            //}
            //else if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    rb.velocity = new Vector3(0, 0, 1) * speed;
            //}
            //else if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    rb.velocity = new Vector3(0, 0, -1) * speed;
            //}
            //else
            //{
            //    rb.velocity = new Vector3();
            //}
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                raycastDirect = (transform.position + (new Vector3(horizontal, 0, vertical)).normalized);
            }

            transform.LookAt(raycastDirect);

            characterController.Move(transform.forward * Time.fixedDeltaTime * speed * Mathf.Min(1.0f, (Mathf.Abs(horizontal) + Mathf.Abs(vertical))));
            animator.SetBool("isIdle", rb.velocity.magnitude <= 0);
            animator.SetBool("isWalking", rb.velocity.magnitude > 0);

        }
    }
}
