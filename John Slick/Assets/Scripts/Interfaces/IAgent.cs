using UnityEngine;
using UnityEngine.Events;

public interface IAgent
{
    int health { get; }
    UnityEvent OnDie { get; set; }
    UnityEvent OnGetHit { get; set; }
}