using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Banger : Grunt
{
    [SerializeField] GameObject explosion = null;
    [SerializeField] float deathSprint = 15f;

    private List<GameObject> targets = new List<GameObject>();
    private float timer = 0f, marchingSpeed = 1f;

    protected override void Start()
    {
        base.Start();
        beginSeeEvent.AddListener(BeginSee);
        endSeeEvent.AddListener(EndSee);
        marchingSpeed = navMeshAgent.speed;
        explosion.transform.parent = null;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (explosion)
        {
            explosion.transform.position = transform.position;
            explosion.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case Status.Wandering:
                {
                    anim.Play("Walk");
                    if (goal)
                    {
                        state = Status.Marching;
                        break;
                    }
                    if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                    {
                        UnityEngine.AI.NavMeshHit navHit;
                        Vector3 dir;
                        dir = transform.position + (Random.onUnitSphere * wanderRange);
                        UnityEngine.AI.NavMesh.SamplePosition(dir, out navHit, wanderRange, -1);
                        navMeshAgent.SetDestination(navHit.position);
                    }
                    break;
                }
            case Status.Marching:
                {
                    anim.Play("Walk");
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
                    anim.Play("Walk");
                    targets.RemoveAll(t => t == null);
                    if (targets.Count > 0)
                    {
                        navMeshAgent.speed = deathSprint;
                        navMeshAgent.SetDestination(targets[0].transform.position);
                        timer += Time.fixedDeltaTime;
                        if (Vector3.Distance(transform.position, targets[0].transform.position) < navMeshAgent.stoppingDistance)
                            state = Status.Attacking;
                    }
                    else
                    {
                        navMeshAgent.speed = marchingSpeed;
                        state = Status.Marching;
                    }
                    break;
                }

            case Status.Attacking:
                {
                    Destroy(gameObject);
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
