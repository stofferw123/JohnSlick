using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IAgent
{
    [field: SerializeField]
    EnemyDataSO EnemyData { get; set; }

    [field: SerializeField]
    public int Health { get; private set; } = 2;
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    bool IsDead = false;

    void Start()
    {
        Health = EnemyData.MaxHealth;
    }

    public void GetHit(int damage = 1, GameObject damageDealer = null)
    {
        if (IsDead) return;
        if (--Health <= 0)
        {
            IsDead = true;    // public death flag so you know
            OnDie?.Invoke();
            Die();
        }
        else
            OnGetHit?.Invoke();
    }

    void Die() // do any dying effecy here
    {
        StopAllCoroutines();
        StartCoroutine("WaitToDie");
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(0.54f);
        Destroy(gameObject); // dont do this
    }
}
