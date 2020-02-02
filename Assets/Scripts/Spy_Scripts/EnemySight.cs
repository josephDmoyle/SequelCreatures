using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{
    [SerializeField] FollowThePath path;
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    Animator animator;

    //  private SphereCollider col;
    private GameObject player;

    private void Start()
    {
        animator = path.animator;
    }
    void Update()
    {
        if(animator == null)
        {
            animator = path.animator;
        }
    }

    void OnTriggerStay(Collider other)
    {
        //if tag eplayer collides with sphere colider or enemy collider
        if (other.gameObject.tag == "Player")
        {
            //Destory player
            Destroy(player);
        }
    }


        void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.tag == "Spy")
            {
                Debug.Log("ENEMY SIGHTED");
                path.keepMoving = false;
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
                Destroy(other.gameObject);
            }
        }
}
