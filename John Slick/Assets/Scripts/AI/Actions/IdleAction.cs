using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        aiMovementData.Direction = Vector2.zero;
        aiMovementData.PointOfInterest = transform.position;

        enemyPathFinder.StopMove();
       // enemyAIBrain.Move(aiMovementData.Direction, aiMovementData.PointOfInterest);
    }
}
