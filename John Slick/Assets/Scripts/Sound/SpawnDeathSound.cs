using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeathSound : MonoBehaviour
{
    [SerializeField]
    GameObject Sound;

    public void SpawnSound()
    {
        Instantiate(Sound, transform.position, Quaternion.identity);
    }
}
