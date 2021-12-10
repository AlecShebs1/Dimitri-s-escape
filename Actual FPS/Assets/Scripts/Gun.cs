using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun: MonoBehaviour
{
    int id;
    float nextFire;

    [SerializeField]public int currentAmmo;
    [SerializeField] public int maxAmmo;
    [SerializeField] public int reserveAmmo;

    float reloadSpeed;
    bool reloadings = false;

    GameObject gameController;
    ItemDatabase database;
    public Camera mainCam;
    Animator weaponAnim;

    private AudioSource audio;
    [SerializeField]public ParticleSystem MuzzleFlash;

    Animator anim;

  


    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        database = gameController.GetComponent<ItemDatabase>();
        id = GetComponent<ItemID>().itemID;
        mainCam = Camera.main;
        //weaponAnim = GameObject.FindGameObjectWithTag("WeaponHolder").GetComponentInChildren<Animator>();
        mainCam = Camera.main;

        anim = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();

        audio = GetComponent<AudioSource>();

      

        reloadSpeed = database.weapons[id].reloadSpeed;
        currentAmmo = database.weapons[id].currentAmmo;
        reserveAmmo = database.weapons[id].reserveAmmo;
        maxAmmo = database.weapons[id].maxAmmo;
    }

     void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && !reloadings)
        {
            if (currentAmmo == database.weapons[id].maxAmmo)
            {
                return;
            }
            else
            {
                StartCoroutine(reload());
                return;
            }
        }

        if (Input.GetButton("Fire1") && Time.time >= nextFire && !reloadings) 
        {
            Shoot();
        }
    }

    void Shoot() 
    {
        if (currentAmmo == 0) 
        {
            return;
        }
      
            currentAmmo--;
        MuzzleFlash.Play();

        Vector3 rayOrigin = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            audio.PlayOneShot(audio.clip);
            nextFire = Time.time + 1f / database.weapons[id].fireRate;
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, Camera.main.transform.forward, out hit, database.weapons[id].range))
            {

            
            if (hit.transform.tag == "BasicEnemy")
                Debug.Log(hit.transform.name);
                BasicEnemy Basichealth = hit.transform.GetComponent<BasicEnemy>();


            if (hit.transform.tag == "FastEnemy")
                Debug.Log(" ");
                fast Fasthealth = hit.transform.GetComponent<fast>();
             

            if (hit.transform.tag == "BoomerEnemy")
                Debug.Log(hit.transform.name);
                Boomer Boomerhealth = hit.transform.GetComponent<Boomer>();

            if (hit.transform.tag == "TankEnemy")
                Debug.Log(hit.transform.name);
                TankZombies Tankhealth = hit.transform.GetComponent<TankZombies>();



              if (Basichealth != null) 
             {
                Basichealth.TakeDamage(database.weapons[id].damage);
                
             }
            if (Fasthealth != null)
            {
                Fasthealth.TakeDamage(database.weapons[id].damage);
               
            }
            if (Boomerhealth != null)
            {
                Boomerhealth.TakeDamage(database.weapons[id].damage);
                
            }
            if (Tankhealth != null)
            {
                Tankhealth.TakeDamage(database.weapons[id].damage);
               
            }





            }

       
    }

    IEnumerator reload() 
    {
        int hold;
        if (currentAmmo < database.weapons[id].maxAmmo)
        {
            

            reloadings = true; 
            yield return new WaitForSeconds(reloadSpeed);
            if (reserveAmmo <= 0)
            {
                reserveAmmo = 0;
                currentAmmo = currentAmmo;
            }
            else
            {

                hold = maxAmmo - currentAmmo;
                if (hold > reserveAmmo)
                {
                    currentAmmo = currentAmmo + reserveAmmo;
                    reserveAmmo = 0;
                }
                else 
                {
                    reserveAmmo -= hold;
                    currentAmmo = maxAmmo;
                }
               

            }
          
            reloadings = false;
        }
    }

   
}
