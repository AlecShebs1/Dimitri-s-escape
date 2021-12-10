using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int[] inventory;
    public GameObject[] weaponSlot;

    void Start() 
    {
        inventory = new int[4];
        weaponSlot = new GameObject[4];

        weaponSlot[0] = GameObject.FindGameObjectWithTag("Makarov");
        weaponSlot[1] = GameObject.FindGameObjectWithTag("PPSH");
        weaponSlot[2] = GameObject.FindGameObjectWithTag("SKS");
        weaponSlot[3] = GameObject.FindGameObjectWithTag("Mosin");
      
    }
}
