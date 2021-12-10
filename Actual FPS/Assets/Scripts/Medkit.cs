using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    public float distance;
    public GameObject player;
    CharacterStats playerStats;
    

    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = GetComponent<CharacterStats>();

    }

    // Update is called once per frame
    void Update()
    {
        restoreHealth();
    }

    public void restoreHealth() 
    {
        distance = Vector3.Distance(player.transform.position,transform.position);


        if (distance <= 3 && Input.GetKeyDown(KeyCode.E)) 
        {
            transform.gameObject.SetActive(false);
            player.GetComponent<CharacterStats>().currHealth += 40;
         
           
        }
    }
}
