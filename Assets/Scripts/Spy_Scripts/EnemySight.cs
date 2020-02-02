using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;

  //  private SphereCollider col;
    private GameObject player;

    void Awake()
    {
        //col = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

  //  void Update()
   // {
      
   // }

    void OnTriggerStay(Collider other)
    {
        //if tag eplayer collides with sphere colider or enemy collider
        if (other.gameObject.tag == "Player")
        {
            //Destory player
            Destroy(player);
        }
    }


        void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.tag == "Player")
            {
                Destroy(player);
            }
        }
}
