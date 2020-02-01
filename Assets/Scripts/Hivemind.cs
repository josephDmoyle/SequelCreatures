using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hivemind : MonoBehaviour
{
    public static Dictionary<Team, Hivemind> hiveminds = new Dictionary<Team, Hivemind>();
    public class PursueEvent : UnityEvent<Transform> { };
    public PursueEvent pursueEvent = new PursueEvent();

    [SerializeField] Team team = Team.Antags;

    [SerializeField] Transform goal = null;

    private void Awake()
    {
        hiveminds[team] = this;
    }

    private void FixedUpdate()
    {
        if(pursueEvent != null)
            pursueEvent.Invoke(goal);
    }
}

public enum Team
{
    Protags,
    Antags,
}
