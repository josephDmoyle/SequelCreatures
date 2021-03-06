﻿using System;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.AI;

public class FollowThePath : MonoBehaviour
{
    public int rotation = 90;
    [SerializeField]public Animator animator;
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField] NavMeshAgent nma = null;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;
    public bool keepMoving = true;

    // Use this for initialization
    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        animator.GetComponent<Animator>();
        animator.SetBool("isWalking", true);
        // Set position of Enemy as position of the first waypoint

    }

    // Update is called once per frame
    private void Update()
    { 
        // Move Enemy
        //Move();
        if(Vector3.Distance(waypoints[waypointIndex].position, transform.position) < nma.stoppingDistance)
        {
            waypointIndex = (waypointIndex + 1)%waypoints.Length;
            nma.SetDestination(waypoints[waypointIndex].position);
        }
        Attacking();
    }

    private void Attacking()
    {
        
    }

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1 && keepMoving)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", true);
            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
            transform.LookAt(waypoints[waypointIndex].position);
            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
                //transform.Rotate(0,rotation,0, Space.Self);
            }
        }
        if (waypointIndex > waypoints.Length - 1)
        {
            waypointIndex = 0;
        }

    }
}
