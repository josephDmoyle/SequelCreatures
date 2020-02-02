using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{
    [SerializeField] FollowThePath path;
    [SerializeField] SpyController spy;
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    Animator animator;
    [SerializeField] NavMeshAgent nma = null;
    [SerializeField] Animator spyAnimator;

    //  private SphereCollider col;
    private GameObject player;

    private void Start()
    {
        animator = path.animator;
        spyAnimator = spy.animator;
       
    }
    void Update()
    {
        if(animator == null)
        {
            animator = path.animator;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Spy")
        {
            Debug.Log("ENEMY SIGHTED");
            nma.isStopped = true;
            Invoke("ResumeMoving", 2f);
            path.keepMoving = false;
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
            spyAnimator.SetBool("isWalking", false);
            spyAnimator.SetBool("isDead", true);
            spy.defeated = true;
        }
    }

    void ResumeMoving()
    {
        nma.isStopped = false;
    }
}
