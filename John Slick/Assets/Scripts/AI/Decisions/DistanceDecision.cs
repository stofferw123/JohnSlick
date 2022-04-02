using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDecision : AIDescision
{
    [field: SerializeField]
    [field: Range(0.1f, 10)]
    public float Distance { get; set; } = 5;
    public override bool MakeDescision()
    {
        if (Vector3.Distance(enemyAIBrain.Target.transform.position, transform.position) < Distance)
        {
            if (!aiActionData.TargetSpotted)
            {
                aiActionData.TargetSpotted = true;
            }
        }
        else
        {
            aiActionData.TargetSpotted = false;
        }
        return aiActionData.TargetSpotted;
    }

    //protected void OnDrawGizmos()
    //{
    //    if(UnityEditor.Selection.activeObject == gameObject)
    //    {
    //        Gizmos.color = Color.yellow;
    //        Gizmos.DrawWireSphere(transform.position, Distance);
    //        Gizmos.color = Color.white;
    //    }
    //}
}
