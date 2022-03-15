using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    [field: SerializeField]
    public List<AIDescision> Decisions { get; set; }
    [field: SerializeField]
    public AIState PositiveResult { get; set; }
    [field: SerializeField]
    public AIState PositiveNegativeResult { get; set; }

    private void Awake()
    {
        Decisions.Clear();
        Decisions = new List<AIDescision>(GetComponents<AIDescision>());
    }
}
