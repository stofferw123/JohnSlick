using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIActionData aiActionData;
    protected AIMovementData aiMovementData;
    protected EnemyAIBrain enemyAIBrain;
    protected EnemyPathFinder enemyPathFinder;

    private void Awake()
    {
        enemyPathFinder = transform.root.GetComponent<EnemyPathFinder>();
        aiActionData = transform.root.GetComponentInChildren<AIActionData>();
        aiMovementData = transform.root.GetComponentInChildren<AIMovementData>();
        enemyAIBrain = transform.root.GetComponent<EnemyAIBrain>();
    }

    public abstract void TakeAction();
}
