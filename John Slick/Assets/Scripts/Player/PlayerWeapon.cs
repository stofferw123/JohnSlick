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
        //uiWeaponIcons.Initialize();
        uiWeaponIcons.UpdateWeaponIcon(0);
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

    public void SetWeapon(Weapon _weapon, int index)
    {
        weapon = _weapon;
        uiWeaponIcons.UpdateWeaponIcon(index); // no work?!??
        weapon.OnAmmoChange.AddListener(uiAmmo.UpdateBulletsText);
    }
}
