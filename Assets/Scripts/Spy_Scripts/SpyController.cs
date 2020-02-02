using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyController : MonoBehaviour
{
    [SerializeField] SpriteBillboard sb;
    Rigidbody rb;
    public float speed = 10.0f;
    private GameObject player;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sb.gameObject.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = -transform.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0, 0, 1) * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0, 0, -1) * speed;
        }
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
}
