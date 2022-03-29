using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    [SerializeField]
    GameObject effect;

    public void SpawnEffect()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
