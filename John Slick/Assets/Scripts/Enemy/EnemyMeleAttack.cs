using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleAttack : EnemyAttack
{
    public override void Attack(int damage) // show the attack with some kind of effect
    {
        //Debug.Log("We are calling enemy attack"); // as i thought, this is called every godanm frame, sure dealing dmg only happens on a timer but we call it all the time
        if(waitBeforeAttack == false)
        {
            var hittable = GetTarget().GetComponent<IHittable>();
            hittable?.GetHit(damage,gameObject);
            StartCoroutine("WaitBeforeAttack");
        }
    }
}
