using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [SerializeField]
    private int maxHealth;

    private int health;

    [SerializeField]
    public int Health { 
        get => health; 
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
<<<<<<< HEAD
            uiHealth.UpdateUI(health);
=======
            uiHealth.UpdateUI(Health);
>>>>>>> cfc08f6c8c598c5721e5e0dec8eb9bfdae3e90f2
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
        Health = maxHealth;
        uiHealth.Initialize(Health);
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if(IsDead) return;
        Health -= damage; // auch
        OnGetHit?.Invoke();
        
        if(Health <= 0)
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
