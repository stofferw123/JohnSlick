using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.Direction = Vector2.zero;
        aiMovementData.PointOfInterest = enemyAIBrain.Target.transform.position;
       // enemyAIBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);

        //enemyPathFinder.StopMove(); // we could want to move while attacking, dont se why not

        aiActionData.Attack = true;
        enemyAIBrain.Attack();
    }
}
