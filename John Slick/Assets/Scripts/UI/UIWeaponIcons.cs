using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponIcons : MonoBehaviour
{
    [SerializeField]
    public Sprite MainWeapon, UpcommingWeapon, LastWeapon;
    List<Sprite> weapons;

    [SerializeField]
    List<Image> images;

    [SerializeField]
    private GameObject WeaponPanel = null;

    Color Fade = new Color(255, 255, 255, 10);
    Color NoFade = new Color(255, 255, 255, 255);


    private void Awake()
    {
        weapons = new List<Sprite>();
        weapons.Add(MainWeapon);
        weapons.Add(UpcommingWeapon);
        weapons.Add(LastWeapon);


        for (int i = 0; i < 3; i++)
        {
            images.Add(transform.GetChild(i).GetComponent<Image>());
        }
    }

    public void Initialize(Sprite mainWeapon, Sprite upcommingWeapon, Sprite lastWeapon) // this is never called, but we would also set the sprites through the inspector
    {   
        MainWeapon = mainWeapon;
        UpcommingWeapon = upcommingWeapon;
        LastWeapon = lastWeapon;
    }

    public void UpdateWeaponIcon(int currentIndex)
    {
        if(currentIndex >= weapons.Count)
        {
            currentIndex = 0;
        }
        MainWeapon = weapons[currentIndex];
       // MainWeapon = UpcommingWeapon;
        UpcommingWeapon = LastWeapon;
        LastWeapon = MainWeapon;



        for (int i = 0; i < weapons.Count; i++)
        {
            if (i == currentIndex)
            {
                images[i].color = NoFade;
            }

            else
            {
                images[i].color = new Color(0,0,0,100);
            }
        }
    }
}
