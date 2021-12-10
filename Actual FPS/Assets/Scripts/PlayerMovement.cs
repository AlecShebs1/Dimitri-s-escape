using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField]public float speed = 6f;
    public float sprint = 12f; //12
    [SerializeField] Vector3 velocity;
    public float gravity = -9.81f;

    private float lastRegen;
    private float staminaRegenSpeed =.75f;
    private float staminaRegenAmount = 1f;

    public bool sprinting = false;

    [SerializeField]GameObject mak;
    [SerializeField] GameObject ppsh;
    [SerializeField] GameObject sks;
    [SerializeField] GameObject mosin;

    public Animator ppshanim;
    public Animator mosinanim;
    public Animator sksanim;

    public Animator anim;

    CharacterStats playerStats;

    public AudioSource sanic;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerStats = GetComponent<CharacterStats>();

        sanic = GetComponent<AudioSource>();

      
    }


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        RegenStamina();

        
        


        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift) && z == 1)
        {
          

           
            if (playerStats.currStamina > 0) {
                sprinting = true;
                controller.Move(move * sprint * Time.deltaTime);
                anim.SetInteger("condition", 2);
                playerStats.currStamina -= 5 * Time.deltaTime;
                playerStats.CheckStamina();
            }
        }
        else 
        {
            controller.Move(move * speed * Time.deltaTime);
            sprinting = false;
        
          
        }

        if (z != 0 && !Input.GetKey(KeyCode.LeftShift)) 
        {
            anim.SetInteger("condition", 1);
        
           
        }
        if (z == 0)
        {
            anim.SetInteger("condition", 0);
         
            
        }

        if (Input.GetKeyDown(KeyCode.R) && mak.activeSelf == true)
        {
            anim.SetTrigger("makReload");
        }

        if (Input.GetKeyDown(KeyCode.R) && ppsh.activeSelf == true) 
        {
            anim.SetTrigger("ppshReload");
         
        }

        if (Input.GetKeyDown(KeyCode.R) && sks.activeSelf == true)
        {
            anim.SetTrigger("sksReload");
        }
        if (Input.GetKeyDown(KeyCode.R) && mosin.activeSelf == true)
        {
            anim.SetTrigger("mosinReload");
        }


        controller.Move(velocity * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && playerStats.currStamina >= 10)
            {
                velocity.y = Mathf.Sqrt(1.5f * -1.5f * gravity);
                anim.SetTrigger("jumpTrigger");
                playerStats.currStamina -= 10;
                playerStats.CheckStamina();
            }
            else 
            {
                return;
            }
         


            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }


        }


    }

    void RegenStamina() 
    {
        if (Time.time - lastRegen > staminaRegenSpeed && !sprinting && playerStats.currStamina < playerStats.maxStamina) 
        {
            playerStats.currStamina += staminaRegenAmount;
            lastRegen = Time.time;
            playerStats.CheckStamina();
        }
    }
 
     

   
}
