﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hivemind : MonoBehaviour
{
    public static Dictionary<Team, Hivemind> hiveminds = new Dictionary<Team, Hivemind>();

    public class PursueEvent : UnityEvent<Transform> { };
    public PursueEvent pursueEvent = new PursueEvent();

    [SerializeField] Team team = Team.Antags;
    [SerializeField] float interval = 1f;
    [SerializeField] Transform goal = null;

    float timer = 0f;

    private void Awake()
    {
        hiveminds[team] = this;
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer >= interval)
        {
            if (pursueEvent != null)
            {
                pursueEvent.Invoke(goal);
                Debug.Log(team.ToString() + " MINIONS, BEGIN MARCH ON " + goal.name);
            }
            timer = 0f;
        }
    }
}

public enum Team
{
    Protags,
    Antags,
}
