using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Grublin : MonoBehaviour
{
    public static Dictionary<GameObject, Grublin> grublins = new Dictionary<GameObject, Grublin>();

    [SerializeField] NavMeshAgent navMeshAgent = null;
    [SerializeField] Team team = Team.Antags;

    private void Start()
    {
        Hivemind.hiveminds[team].pursueEvent.AddListener(Pursue);
    }

    public void Pursue(Transform iTransform)
    {
        if (iTransform)
            navMeshAgent.SetDestination(iTransform.position);
        else
            navMeshAgent.SetDestination(transform.position);
    }

    private void FixedUpdate()
    {
    }
}
