using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt_Shooter : Grunt
{
    [SerializeField] Transform shootPosition = null;
    [SerializeField] private List<Rigidbody> projectiles = new List<Rigidbody>();
    [SerializeField] [Range(0.1f, 10f)] float countDown = 1f;
    [SerializeField] float projectileSpeed = 10f;

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
                        if (timer >= countDown)
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
                    Rigidbody rb = magazine.Dequeue();
                    rb.gameObject.SetActive(true);
                    rb.position = shootPosition.position;
                    rb.velocity = shootPosition.forward.normalized * projectileSpeed;
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
