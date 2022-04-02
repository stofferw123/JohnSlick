using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponSwapper : MonoBehaviour
{
    [SerializeField]
    int currentWeaponIndex = 0;
    public List<GameObject> weapons;

    PlayerWeapon playerWeapon;

    private void Awake()
    {
        playerWeapon = GetComponent<PlayerWeapon>();
        weapons = new List<GameObject>();

        for (int i = 0; i < 3; i++)
        {
            weapons.Add(transform.GetChild(i).gameObject);
        }
        currentWeaponIndex = weapons.IndexOf(weapons.FirstOrDefault(x => x.activeInHierarchy == true));
    }

    public void Switch()
    {
        currentWeaponIndex++;
        if(currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }

        for (int i = 0; i < weapons.Count; i++)
        {
            if(i == currentWeaponIndex)
            {
                weapons[i].SetActive(true);
            }
            else
                weapons[i].SetActive(false);
        }

        playerWeapon.SetWeapon(weapons[currentWeaponIndex].GetComponent<Weapon>(), currentWeaponIndex);
    }
}
