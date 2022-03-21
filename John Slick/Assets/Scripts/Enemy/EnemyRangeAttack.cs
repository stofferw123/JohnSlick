using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyRangeAttack : EnemyAttack
{
    [SerializeField]
    private GameObject Projectile;

    public override void Attack(int damage) // needs some work
    {
        if (waitBeforeAttack == false)
        {
            Vector2 directionToTarget = GetTarget().transform.position - transform.position;
            float angle = Vector3.Angle(Vector3.right, directionToTarget);
            if (GetTarget().transform.position.y < transform.position.y) angle *= -1;
            Quaternion bulletRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject p = Instantiate(Projectile, transform.position, bulletRotation);
            StartCoroutine("WaitBeforeAttack");
        }
    }
}
