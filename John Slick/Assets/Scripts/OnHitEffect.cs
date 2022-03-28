using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitEffect : MonoBehaviour
{
    [SerializeField]
    private int dmg;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Player")) return;
        gameObject.SetActive(false);
        other.gameObject?.GetComponentInParent<IHittable>()?.GetHit(dmg, this.gameObject);
    }
}
