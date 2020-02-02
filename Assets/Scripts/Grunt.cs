using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public abstract class Grunt : MonoBehaviour
{
    public static Dictionary<GameObject, Grunt> grunts = new Dictionary<GameObject, Grunt>();

    public class SeeEvent : UnityEvent<GameObject> { };
    public SeeEvent beginSeeEvent = new SeeEvent(), endSeeEvent = new SeeEvent();
    public Team team = Team.Antags;

    protected Status state = Status.Wandering;
    protected Transform goal = null;
    [SerializeField] protected float wanderRange = 10f;
    [SerializeField] protected Animator anim = null;
    [SerializeField] protected NavMeshAgent navMeshAgent = null;

    private void Awake()
    {
        grunts[gameObject] = this;
    }

    protected virtual void OnDestroy()
    {
        grunts.Remove(gameObject);
    }

    protected virtual void Start()
    {
        Hivemind.hiveminds[team].pursueEvent.AddListener(Pursue);
    }

    public void Pursue(Transform iTransform)
    {
        goal = iTransform;
    }

    protected virtual void OnTriggerEnter(Collider iOther)
    {
        if (!iOther.isTrigger)
            if (grunts.ContainsKey(iOther.gameObject))
            {
                if (beginSeeEvent != null)
                    beginSeeEvent.Invoke(iOther.gameObject);
            }
    }

    protected virtual void OnTriggerExit(Collider iOther)
    {
        if (!iOther.isTrigger)
            if (grunts.ContainsKey(iOther.gameObject))
            {
                if (endSeeEvent != null)
                    endSeeEvent.Invoke(iOther.gameObject);
            }
    }
}

public enum Status
{
    Wandering,
    Marching,
    Engaging,
    Attacking,
}
