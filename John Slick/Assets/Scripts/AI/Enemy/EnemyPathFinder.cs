using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class EnemyPathFinder : MonoBehaviour
{
    [SerializeField]
    AgentMovement agentMovement;

    Transform target;

    [SerializeField]
    float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    bool canMove = true;

    AgentRenderer agentRenderer;

    private void Start()
    {
        agentRenderer = GetComponentInChildren<AgentRenderer>();
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();

        //InvokeRepeating("UpdatePath", 0, 0.15f);
        InvokeRepeating("UpdatePath", 1, 0.75f);

    }
    void UpdatePath()
    {
        if(!target) return;
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
        agentRenderer.FaceDirectionEnemy(direction);

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
