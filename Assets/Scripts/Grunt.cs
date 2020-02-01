using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Grunt : MonoBehaviour
{
    public static Dictionary<GameObject, Grunt> grublins = new Dictionary<GameObject, Grunt>();

    [SerializeField] NavMeshAgent navMeshAgent = null;
    [SerializeField] Team team = Team.Antags;

    private void Awake()
    {
        grublins[gameObject] = this;
    }

    private void OnDestroy()
    {
        grublins.Remove(gameObject);
    }

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

    protected virtual void OnTriggerEnter(Collider iOther)
    {
        if (!iOther.isTrigger)
            if (grublins.ContainsKey(iOther.gameObject))
                Debug.Log(transform.name + " sees: " + iOther.transform.name);
    }

    protected virtual void OnTriggerExit(Collider iOther)
    {
        if (!iOther.isTrigger)
            if (grublins.ContainsKey(iOther.gameObject))
                Debug.Log(transform.name + " looses sight of: " + iOther.transform.name);
    }
}
