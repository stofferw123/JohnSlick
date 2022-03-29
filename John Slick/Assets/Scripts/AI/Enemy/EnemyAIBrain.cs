using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAIBrain : MonoBehaviour, IAgentInput
{
    public GameObject Target;

    [field: SerializeField]
    public AIState CurrentState { get; set; }

    [field: SerializeField]
    public UnityEvent OnFireButtonReleased { get; set; }
    [field: SerializeField]
    public UnityEvent OnFireButtonPressed { get; set; }
    [field: SerializeField]
    public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    [field: SerializeField]
    public UnityEvent<Vector2> OnPointerPositionChange { get; set; }


    void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Target == null)
        {
            OnMovementKeyPressed?.Invoke(Vector2.zero);
        }
        else
        {
            CurrentState.UpdateState(); // do we even want to update state if there is no target?, we will never not have the player in the scene
        }
    }

    public void Attack()
    {
        OnFireButtonPressed?.Invoke();
    }

    public void Move(Vector2 movementDirection, Vector2 targePos)
    {
        OnMovementKeyPressed?.Invoke(movementDirection);
        OnPointerPositionChange?.Invoke(targePos);
    }

    internal void ChangeToState(AIState state)
    {
        if (state == null) return;
        CurrentState = state;
    }
}
