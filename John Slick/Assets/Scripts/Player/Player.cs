using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent, IHittable
{
    [field: SerializeField]
    public int health { get; set; }
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }
    [field: SerializeField]
    public UnityEvent OnGetHit { get; set; }

    bool IsDead = false;

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
