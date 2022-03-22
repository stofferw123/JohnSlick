using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField]
    private int maxHealth;

    private int health;

    [field: SerializeField]
    public int Health { 
        get => health; 
        set
        {
            Health = Mathf.Clamp(value, 0, maxHealth);
            uiHealth.UpdateUI(health);
        } 
    }

    private bool Dead;

    [field: SerializeField]
    public UIHealth uiHealth { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    private void Start()
    {
        health = maxHealth;
        uiHealth.Initialize(health);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if (Dead == false)
        {
            Health -= damage;
            OnGetHit?.Invoke();
            if (Health <= 0)
            {
                OnDie?.Invoke();
                Dead = true;
                StartCoroutine(DeathCoroutine());
            }
        }
    }
    IEnumerator DeathCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
