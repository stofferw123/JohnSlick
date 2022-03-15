using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    private EnemyAIBrain enemyAIBrain;
    [field: SerializeField]
    private List<AIAction> actions;
    [field: SerializeField]
    private List<AITransition> transitions;

    private void Awake()
    {
        enemyAIBrain = transform.root.GetComponent<EnemyAIBrain>();
    }

    public void UpdateState()
    {
        foreach (var action in actions)
        {
            action.TakeAction();
        }
        foreach (var transition in transitions)
        {
            bool result = false;
            foreach (var descision in transition.Decisions)
            {
                result = descision.MakeDescision();
                if (result == false)
                    break;

            }
            if (result)
            {
                if(transition.PositiveResult != null)
                {
                    enemyAIBrain.ChangeToState(transition.PositiveResult);
                    return;
                }
            }
            else
            {
                if(transition != null)
                {
                    enemyAIBrain.ChangeToState(transition.PositiveNegativeResult);
                    return;
                }
            }
        }
    }

}
