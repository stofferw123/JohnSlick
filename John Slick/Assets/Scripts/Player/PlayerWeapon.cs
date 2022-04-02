using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : AgentWeapon
{
    [SerializeField]
    private UIAmmo uiAmmo = null;

    [SerializeField]
    private UIWeaponIcons uiWeaponIcons = null;

    public bool AmmoFull { get => weapon != null && weapon.AmmoFull; }

    private void Start()
    {
        uiWeaponIcons.UpdateWeaponIcon();
        if (weapon != null)
        {
            weapon.OnAmmoChange.AddListener(uiAmmo.UpdateBulletsText);
            uiAmmo.UpdateBulletsText(weapon.Ammo);
        }
    }

    public void AddAmmo(int amount)
    {
        if (weapon != null)
        {
            weapon.Ammo += amount;
        }
    }

    public void SetWeapon(Weapon _weapon)
    {
        weapon = _weapon;
        //uiWeaponIcons.UpdateWeaponIcon(); // no work?!??
        weapon.OnAmmoChange.AddListener(uiAmmo.UpdateBulletsText);
    }
}
