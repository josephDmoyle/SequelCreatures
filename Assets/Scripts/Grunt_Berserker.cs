using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Berserker : Grunt
{
    [SerializeField] [Range(0.1f, 10f)] float coolDown = 1f;

    private List<GameObject> targets = new List<GameObject>();
    private float timer = 0f, marchingSpeed = 1f;

    protected override void Start()
    {
        base.Start();
        beginSeeEvent.AddListener(BeginSee);
        endSeeEvent.AddListener(EndSee);
        marchingSpeed = navMeshAgent.speed;
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case Status.Marching:
                {
                    //Go to Goal or stand still if there isn't one
                    if (goal)
                        navMeshAgent.SetDestination(goal.position);
                    else
                        navMeshAgent.SetDestination(transform.position);

                    //Engage a target if there is one
                    if (targets.Count > 0)
                        state = Status.Engaging;

                    timer = 0f;
                    break;
                }

            case Status.Engaging:
                {
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
