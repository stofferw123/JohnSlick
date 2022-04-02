using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponIcons : MonoBehaviour
{
    [SerializeField]
    public Sprite MainWeapon, UpcommingWeapon, LastWeapon = null;

    [SerializeField]
    private GameObject WeaonPanel = null;

    public void Initialize(Sprite mainWeapon, Sprite upcommingWeapon, Sprite lastWeapon)
    {
        
        MainWeapon = mainWeapon;
        UpcommingWeapon = upcommingWeapon;
        LastWeapon = lastWeapon;
    }

    public void UpdateWeaponIcon()
    {
        MainWeapon = UpcommingWeapon;
        UpcommingWeapon = LastWeapon;
        LastWeapon = MainWeapon;
    }
}
