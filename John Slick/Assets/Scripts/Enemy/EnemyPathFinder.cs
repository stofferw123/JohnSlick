using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyPathFinder : MonoBehaviour
{
    [SerializeField]
    AgentMovement agentMovement;

    public Transform target;

    public float speed = 0.5f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    bool canMove = true;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();

        InvokeRepeating("UpdatePath", 0, 0.15f);
    }

    void UpdatePath()
    {
        seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (path == null || !canMove) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        agentMovement.MoveAgent(direction);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    public void StopMove()
    {
        canMove = false;
        agentMovement.MoveAgent(Vector2.zero);
    }
    public void CanMove()
    {
        canMove = true;
    }
}
