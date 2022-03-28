using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    EnemyAIBrain enemyAIBrain { get; set; }

    [field: SerializeField]
    public float AttackDelay{get; private set;} = 1;
    protected bool waitBeforeAttack;
    private void Awake()
    {
        enemyAIBrain = GetComponent<EnemyAIBrain>();
    }

    public abstract void Attack(int damage);

    protected IEnumerator WaitBeforeAttack()
    {
        waitBeforeAttack = true;
        yield return new WaitForSeconds(AttackDelay);
        waitBeforeAttack = false;
    }

    protected GameObject GetTarget()
    {
        return enemyAIBrain.Target;
    }
}
