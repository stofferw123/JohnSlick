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

    bool IsDead = false;
  
    [field: SerializeField]
    public UIHealth uiHealth { get; set; }

    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    private void Awake()
    {
        health = maxHealth;
        uiHealth.Initialize(health);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if(IsDead) return;
        health -= damage; // auch
        OnGetHit?.Invoke();
        
        if(health <= 0)
        {
            IsDead = true;
            OnDie?.Invoke();
            StartCoroutine(Death());
        }
       // Debug.Log("Player got hit by: " + damageDealer.name);
    }

    IEnumerator Death()
    {
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f); // should probably just reload scene here instead  
        // do something
    }
}
