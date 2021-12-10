using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    public GameObject[] list;

    public GameObject player;
    public GameObject spawn;

    public int ActiveSpawn;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");


        //distance = Vector3.Distance();
        //distance from the correct esacpe after iterating through the list of gameobjects

        list = new GameObject[3];

        for (int i = 0; i < list.Length; i++)
        {
            list[i] = transform.GetChild(i).gameObject;
        }

        ActiveSpawn = Random.Range(1, 4);
        findSpawn();

        player.transform.position = spawn.transform.position;
    }

    
    

    void findSpawn()
    {
        for (int i = 0; i < list.Length; i++)
        {

            if (list[i].GetComponentInChildren<SpawnID>().SpawnIDs == ActiveSpawn)
            {
                spawn = list[i].gameObject;
               
            }
        }
    }
}
