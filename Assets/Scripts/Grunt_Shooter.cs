using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Grunt_Shooter : Grunt
{
    [SerializeField] Transform shootPosition = null;
    [SerializeField] private List<Rigidbody> projectiles = new List<Rigidbody>();
    [SerializeField] [Range(0.1f, 10f)] float coolDown = 1f;
    [SerializeField] Vector3 projectileSpeed = Vector3.forward;

    private List<GameObject> targets = new List<GameObject>();
    private float timer = 0f;
    private Queue<Rigidbody> magazine = new Queue<Rigidbody>();

    protected override void Start()
    {
        base.Start();
        beginSeeEvent.AddListener(BeginSee);
        endSeeEvent.AddListener(EndSee);
        foreach (Rigidbody rb in projectiles)
            magazine.Enqueue(rb);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        foreach (Rigidbody rb in projectiles)
            if (rb)
                Destroy(rb.gameObject);
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case Status.Wandering:
                {
                    anim.SetBool("walk", true);
                    if (goal)
                    {
                        state = Status.Marching;
                        break;
                    }
                    if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                    {
                        NavMeshHit navHit;
                        Vector3 dir;
                        dir = transform.position + (Random.onUnitSphere * wanderRange);
                        NavMesh.SamplePosition(dir, out navHit, wanderRange, -1);
                        navMeshAgent.SetDestination(navHit.position);
                    }
                    break;
                }
            case Status.Marching:
                {
                    anim.SetBool("walk", true);
                    //Go to Goal or stand still if there isn't one
                    if (goal)
                        navMeshAgent.SetDestination(goal.position);
                    else
                        state = Status.Wandering;

                    //Engage a target if there is one
                    if (targets.Count > 0)
                        state = Status.Engaging;

                    break;
                }

            case Status.Engaging:
                {
                    anim.SetBool("walk", false);
                    targets.RemoveAll(t => t == null);
                    if (targets.Count > 0)
                    {
                        transform.LookAt(targets[0].transform.position);
                        navMeshAgent.isStopped = true;

                        timer += Time.fixedDeltaTime;
                        if (timer >= coolDown)
                            state = Status.Attacking;
                    }
                    else
                    {
                        navMeshAgent.isStopped = false;
                        state = Status.Marching;
                    }
                    break;
                }

            case Status.Attacking:
                {
                    int r = Random.Range(1, 3);
                    if(r == 1)
                    {
                        SFX.Playsound("aliengun");
                    }
                    else if (r == 2)
                    {
                        SFX.Playsound("aliengun2");
                    }
                    else if (r == 3)
                    {
                        SFX.Playsound("aliengun3");
                    }
                    anim.SetTrigger("attack");
                    Rigidbody rb = magazine.Dequeue();
                    rb.transform.parent = null;
                    rb.gameObject.SetActive(true);
                    rb.position = shootPosition.position;
                    rb.velocity = transform.TransformDirection(projectileSpeed);
                    magazine.Enqueue(rb);
                    timer = 0f;
                    state = Status.Engaging;
                    break;
                }
        }
    }

    void BeginSee(GameObject iGameObject)
    {
        if(grunts[iGameObject].team != team && !targets.Contains(iGameObject))
        {
            state = Status.Engaging;
            targets.Add(iGameObject);
        }
    }

    void EndSee(GameObject iGameObject)
    {
        if (targets.Contains(iGameObject))
        {
            targets.Remove(iGameObject);
            if (targets.Count == 0)
                navMeshAgent.isStopped = false;
        }
    }
}
