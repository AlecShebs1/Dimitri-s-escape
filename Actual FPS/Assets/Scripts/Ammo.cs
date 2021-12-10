using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float distance;
    public GameObject player;

     GameObject gameController;
     ItemDatabase database;
     int id;


    [SerializeField]GameObject mak;
    [SerializeField]GameObject ppsh;
    [SerializeField]GameObject sks;
    [SerializeField]GameObject mosin;

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
        
    }

    // Update is called once per frame
    void Update()
    {
        restoreAmmo();
    }

    public void restoreAmmo()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);


        if (distance <= 3 && Input.GetKeyDown(KeyCode.E))
        {
            transform.gameObject.SetActive(false);

            mak.GetComponentInChildren<Gun>().reserveAmmo += mak.GetComponentInChildren<Gun>().maxAmmo;
            ppsh.GetComponentInChildren<Gun>().reserveAmmo += ppsh.GetComponentInChildren<Gun>().maxAmmo;
            sks.GetComponentInChildren<Gun>().reserveAmmo += sks.GetComponentInChildren<Gun>().maxAmmo;
            mosin.GetComponentInChildren<Gun>().reserveAmmo += mosin.GetComponentInChildren<Gun>().maxAmmo;
        }
     
    }
}
