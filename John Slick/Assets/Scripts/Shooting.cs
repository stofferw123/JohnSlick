using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject Projectile;

    [SerializeField]
    GameObject FirePoint;

    [SerializeField]
    Move Player;

    [SerializeField]
    ObjectPooling objectPooling;

    [SerializeField]
    string ProjectileTag;

    [SerializeField]
    float Cooldown;
    bool CanShoot;

    private void Awake()
    {
        CanShoot = true;
    }

    void Update()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var shootRotation = Quaternion.AngleAxis(angle, Vector3.forward);


        if (Input.GetKeyDown(KeyCode.Mouse0) && CanShoot)
        {
            // Instantiate(Projectile, FirePoint.transform.position, shootRotation);
            StopAllCoroutines();
            StartCoroutine("ShootCD");

            objectPooling.GetObject(FirePoint.transform.position, shootRotation, ProjectileTag);

            Player.PushObject(-dir);
        }
    }


    IEnumerator ShootCD()
    {
        CanShoot = false;
        yield return new WaitForSeconds(Cooldown);
        CanShoot = true;
    }
}
