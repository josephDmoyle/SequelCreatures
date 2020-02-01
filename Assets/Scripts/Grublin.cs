using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Grublin : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent = null;

    private void FixedUpdate()
    {
        navMeshAgent.SetDestination(Hivemind.hivemind.goal.position);
    }
}
