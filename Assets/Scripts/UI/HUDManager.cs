using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; set; }

    //UI
    public TextMeshProUGUI currentAmmo;
    public TextMeshProUGUI totalAmmo;

    public Image activeWeapon;
    public Image secondWeapon;

    public Image antiPic;
    public TextMeshProUGUI antiNum;

    public Sprite emptyslot;
    public Sprite rifel;
    public Sprite pistol;
    public Sprite anti;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        antiPic.sprite = anti;
    }

    private void Update()
    {
        antiNum.text = $"{WeaponManager.Instance.totalAntis}";
        Weapon actived = WeaponManager.Instance.activeWeaponSlot.GetComponentInChildren<Weapon>();
        Weapon unacted = GetUnActivedSlot().GetComponentInChildren<Weapon>();

        if (actived)
        {
            currentAmmo.text = $"{actived.bulletLeft / actived.bulletPerBurst}";
            totalAmmo.text = $"{WeaponManager.Instance.CheckAmmoleft(actived.thisweapon)}";

            Weapon.WeaponModel model = actived.thisweapon;

            activeWeapon.sprite = GetWeaponSprite(model);

            if (unacted)
            {
                secondWeapon.sprite = GetWeaponSprite(unacted.thisweapon);
            }
        }
        else
        {
            currentAmmo.text = "";
            totalAmmo.text = "";

            activeWeapon.sprite = emptyslot;
            secondWeapon.sprite = emptyslot;
        }
    }

    private Sprite GetWeaponSprite(Weapon.WeaponModel model)
    {
        switch (model)
        {
            case Weapon.WeaponModel.Rifel:
                return rifel;
            case Weapon.WeaponModel.Pistol:
                return pistol;
            default:
                return null;
        }
    }

    private GameObject GetUnActivedSlot()
    {
        foreach(GameObject slots in WeaponManager.Instance.weaponSlots)
        {
            if(slots != WeaponManager.Instance.activeWeaponSlot)
            {
                return slots;
            }
        }
        return null;
    }
}
