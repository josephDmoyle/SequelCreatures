using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hivemind : MonoBehaviour
{
    public static Dictionary<Team, Hivemind> hiveminds = new Dictionary<Team, Hivemind>();


    [SerializeField] Team team;

    UnityEvent<Transform> pursueEvent;
    Transform goal = null;

    private void Awake()
    {
        hiveminds[team] = this;
    }

    private void FixedUpdate()
    {
        if(goal && pursueEvent != null)
            pursueEvent.Invoke(goal);
    }
}

public enum Team
{
    Protags,
    Antags,
}
