using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent
{

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int health;
    private int Health { get => health; set 
        {
            Health = Mathf.Clamp(value, 0, maxHealth);
            uiHealth.UpdateUI(health);
        } 
    }

    [field: SerializeField]
    public UIHealth uiHealth { get; set; }

    public UnityEvent OnDie { get; set; }
    public UnityEvent OnGetHit { get; set; }

    int IAgent.health => throw new System.NotImplementedException();

    private void Start()
    {
        health = maxHealth;
        uiHealth.Initialize(health);
    }
}
