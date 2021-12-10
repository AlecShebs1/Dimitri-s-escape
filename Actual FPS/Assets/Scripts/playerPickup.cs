using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class playerPickup : MonoBehaviour
//{
  //  public float pickupRange = 2f;
  //  int layerMask;
  //  [SerializeField] GameObject gameController;

  //  ItemDatabase database;
   // PlayerInventory inventory;

   // Camera cam;

   // private void Start()
  //  {
    //    gameController = GameObject.FindGameObjectWithTag("GameContoller");
    //    database = gameController.GetComponent<ItemDatabase>();
    //    inventory = gameController.GetComponent<PlayerInventory>();
   //     cam = GetComponent<Camera>();

   //     layerMask = LayerMask.GetMask("pickup");
  //  }

  //  private void Update()
  //  {
      //  Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
      //  RaycastHit hit;

      //  if (Physics.Raycast(ray, out hit, pickupRange, layerMask)) 
     //   {
        //    if (Input.GetKeyDown(KeyCode.E)
             //   {
                //    int id = hit.transform.GetComponent<ItemID>().itemID;
                 //   if (database.weapons[id].weaponType == 1)
                //    {
                    //    if (inventory.inventory[0] == id)
                    //      {
                     //       Debug.Log("You have this weapon");
                    //}
                    //    else if (inventory.inventory[0] != id)
                    //    {
                   //         inventory.inventory[0] = id;
                   //         Instantiate(database.weapons[id].weaponObject, inventory.weaponSlot[0].gameObject.transform.position, inventory.weaponSlot[0].gameObject.transform.rotation);
               //         }
           //         }
            //    }
       //     }

      //  }
  //  }
//}
