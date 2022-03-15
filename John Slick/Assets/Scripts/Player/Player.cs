using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IAgent
{
    public int health { get; set; }

    public UnityEvent OnDie { get; set; }
    public UnityEvent OnGetHit { get; set; }
}
