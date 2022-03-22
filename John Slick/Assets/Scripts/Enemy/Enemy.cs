using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IAgent, IHittable
{
    [field: SerializeField]
    EnemyDataSO EnemyData { get; set; }

    [field: SerializeField]

    public int Health { get; private set; } = 2;



    [field: SerializeField]
    public EnemyAttack enemyAttack { get; set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    bool IsDead = false;

    void Awake()
    {
        if (enemyAttack == null)
        {
            enemyAttack = GetComponent<EnemyAttack>();
        }
    }

    void Start()
    {
        Health = EnemyData.MaxHealth;
    }

    public void GetHit(int damage = 1, GameObject damageDealer = null)
    {
        OnGetHit?.Invoke();
        if (IsDead) return;
        if (--Health <= 0)

        {
            IsDead = true;    // public death flag so you know
            OnDie?.Invoke();
            Die();
        }
    }

    void Die() // do any dying effect here
    {
        StopAllCoroutines();
        StartCoroutine("WaitToDie");
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(0.54f);
        Destroy(gameObject); // dont do this
    }

    public void PerformAttack()
    {
        if (IsDead) return;
        enemyAttack.Attack(EnemyData.Damage);
    }
}
