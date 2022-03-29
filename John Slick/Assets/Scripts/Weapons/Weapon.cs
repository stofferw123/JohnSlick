using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected GameObject muzzle;
    [SerializeField]
    protected int ammo = 10;
    [SerializeField]
    protected WeaponDataSO weaponData;
    public int Ammo
    {
        get { return ammo; }
        set
        {
            ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapacity);
            OnAmmoChange?.Invoke(ammo);
        }
    }

    public bool AmmoFull
    {
        get => Ammo >= weaponData.AmmoCapacity;
    }

    protected bool isShooting = false;

    [SerializeField]
    protected bool reloadCoroutine = false;

    [field: SerializeField]
    public UnityEvent OnShoot { get; set; }

    [field: SerializeField]
    public UnityEvent OnShootNoAmmo { get; set; }

    [field: SerializeField]
    public UnityEvent<int> OnAmmoChange { get; set; }

    [SerializeField]
    WeaponSwapper swapper;

    AgentMovement playerMove;

    private void Start()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<AgentMovement>();
        Ammo = weaponData.AmmoCapacity;
    }

    public void TryShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    public void Reload(int ammo)
    {
        Ammo = weaponData.AmmoCapacity;
        //Ammo += ammo;
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        CancelInvoke();
        reloadCoroutine = false;
        isShooting = false;
        Reload(0);
    }

    private void Update()
    {
        UseWeapon();
    }

    private void UseWeapon()
    {
        if (isShooting && reloadCoroutine == false)
        {
            if (ammo > 0)
            {
                Ammo--;
                OnShoot?.Invoke();
                playerMove.DoRecoil();
                for (int i = 0; i < weaponData.GetBulletCountToSpawn(); i++)
                {
                    ShootBullet();
                }
            }
            else
            {
                isShooting = false;
                OnShootNoAmmo?.Invoke();
                return;
            }

            FinishShooting();
        }
    }

    void SwitchDelay()
    {
        swapper.Switch();
    }

    private void FinishShooting()
    {
        StartCoroutine(DelayNextShootCoroutine());
        if (weaponData.AutomaticFire == false)
        {
            isShooting = false;
        }
        if (Ammo <= 0)
        {
            Invoke("SwitchDelay", 1); 
        }
    }

    protected IEnumerator DelayNextShootCoroutine()
    {
        reloadCoroutine = true;
        yield return new WaitForSeconds(weaponData.WeaponDelay);
        reloadCoroutine = false;
    }

    private void ShootBullet()
    {
        SpawnBullet(muzzle.transform.position, CalculateAngle(muzzle));
    }

    private void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        var bulletPrefab = Instantiate(weaponData.BulletData.BulletPrefab, position, rotation);
        bulletPrefab.GetComponent<Bullet>().BulletData = weaponData.BulletData;
    }

    private Quaternion CalculateAngle(GameObject muzzle)
    {
        float spread = Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
        Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spread));
        return muzzle.transform.rotation * bulletSpreadRotation;
    }
}
