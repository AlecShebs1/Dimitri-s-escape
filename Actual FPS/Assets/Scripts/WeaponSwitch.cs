using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    // Makarov should be 1
    // ppsh 2
    // sks 3
    // mosin 4
    // Dp28 5
   public int weaponSelected = 1;

    [SerializeField] GameObject ppsh, mosin, makarov, sks;

    

    Animator playerAnimtor;
   

    private void Start()
    {
        playerAnimtor = GetComponentInChildren<Animator>();

        

    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            if (weaponSelected != 1) 
            {
                
               

                playerAnimtor.SetInteger("WeaponType", 1);
                weaponSelected = 1;

              

                makarov.SetActive(true);
                ppsh.SetActive(false);
                mosin.SetActive(false);
               
                sks.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weaponSelected != 2)
            {
            

                playerAnimtor.SetInteger("WeaponType", 2);
                weaponSelected = 2;
               

                makarov.SetActive(false);
                ppsh.SetActive(true);
                mosin.SetActive(false);
             
                sks.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weaponSelected != 3)
            {
              

                playerAnimtor.SetInteger("WeaponType", 3);
                weaponSelected = 3;
               
             

                makarov.SetActive(false);
                ppsh.SetActive(false);
                mosin.SetActive(false);
               
                sks.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (weaponSelected != 4)
            {
               

                playerAnimtor.SetInteger("WeaponType", 4);
                weaponSelected = 4;
                
              

                makarov.SetActive(false);
                ppsh.SetActive(false);
                mosin.SetActive(true);
              
                sks.SetActive(false);
            }
        }

       
    }

  

    

}
