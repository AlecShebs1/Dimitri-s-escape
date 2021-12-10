using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escaping : MonoBehaviour
{
    

    public GameObject[] list;
    public float distance;

    public GameObject player;
    public GameObject escape;

    public int ActiveEscape;
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


        ActiveEscape = Random.Range(1, 4);
        
         findEscape();
       

    }

    // Update is called once per frame
     void Update()
    {
        distance = Vector3.Distance(player.transform.position, escape.transform.position);

        if (distance <= 15 && Input.GetKeyDown(KeyCode.E)) 
        {
            Debug.Log("You ESCAPED!");
            SceneManager.UnloadSceneAsync(1);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
       
    }



    void findEscape() 
    {
        for (int i = 0; i < list.Length; i++) 
        {

            if (list[i].GetComponentInChildren<EsacpeIDs>().EscapeID == ActiveEscape) 
            {
                escape = list[i].gameObject;
                Debug.Log(escape);
               
            }
        }
    }
}
