using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceBullet : Bullet
{
    protected Rigidbody2D rigidbody2d;

    public override BulletDataSO BulletData
    {
        get => base.BulletData;
        set
        {
            base.BulletData = value;
            rigidbody2d = GetComponent<Rigidbody2D>();
            rigidbody2d.drag = BulletData.Friction;
        }
    }

    private void FixedUpdate()
    {
        if (rigidbody2d != null && BulletData != null)
        {
            rigidbody2d.MovePosition(transform.position + BulletData.BulletSpeed * transform.right *
                Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hittable = collision.GetComponent<IHittable>();
        hittable?.GetHit(BulletData.Damage, gameObject);
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle();
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("BulletWallCollider"))
        {
            HitObstacle();
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy();
        }
    }

    private void HitEnemy()
    {
        Debug.Log("Hitting Enemy");
    }

    private void HitObstacle()
    {
        Debug.Log("Hitting Obstacle");
    }

}
