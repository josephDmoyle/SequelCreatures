using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Berserker : Grunt
{
    [SerializeField] [Range(0.1f, 10f)] float coolDown = 1f;
    [SerializeField] Collider attackBox = null;

    private List<GameObject> targets = new List<GameObject>();
    private float timer = 0f;

    protected override void Start()
    {
        base.Start();
        beginSeeEvent.AddListener(BeginSee);
        endSeeEvent.AddListener(EndSee);
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
                    //Go to Goal or stand still if there isn't one
                    anim.SetBool("walk", true);
                    if (goal)
                        navMeshAgent.SetDestination(goal.position);
                    else
                        state = Status.Wandering;

                    //Engage a target if there is one
                    if (targets.Count > 0)
                        state = Status.Engaging;

                    timer = coolDown;
                    break;
                }

            case Status.Engaging:
                {
                    anim.SetBool("walk", true);
                    targets.RemoveAll(t => t == null);
                    if (targets.Count > 0)
                    {
                        navMeshAgent.SetDestination(targets[0].transform.position);
                        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
                        {
                            transform.LookAt(navMeshAgent.destination);
                            if (timer >= coolDown)
                                state = Status.Attacking;
                        }
                        timer += Time.fixedDeltaTime;
                    }
                    else
                    {
                        state = Status.Marching;
                    }
                    break;
                }

            case Status.Attacking:
                {
                    int r = Random.Range(1, 3);
                    if (r == 1)
                        SFX.Playsound("alienchat1");
                    else if (r == 1)
                        SFX.Playsound("humanchatter2");
                    else if (r == 1)
                        SFX.Playsound("alienchat3");
                    anim.SetTrigger("attack");
                    attackBox.gameObject.SetActive(true);
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
