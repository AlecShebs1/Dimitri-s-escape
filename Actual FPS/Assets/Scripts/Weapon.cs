using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Weapon 
{

    public int weaponType;

    public string name;
    public GameObject weaponObject;
  

    public float damage;
    public float fireRate;
    public float range;

    public int itemID;

    public float reloadSpeed;
    public int reserveAmmo;
    public int maxAmmo;
    public int currentAmmo;
}
