using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private GameObject weaponLogic;

    public void EnableWeapon() 
    {
        weaponLogic.SetActive(true);
    }

    public void DisableWeopon()
    {
        weaponLogic.SetActive(false);
    }

}