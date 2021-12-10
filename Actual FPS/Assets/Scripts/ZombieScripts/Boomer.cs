using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boomer : MonoBehaviour
{  // Start is called before the first frame update

    NavMeshAgent agent;
    GameObject target;
    GameObject zombie;

    [SerializeField]ParticleSystem explosion;

    Animator anim;

    float lastAttackTime = 0f;
    float attackCoolDown = 2f;

    private float distance;
    public float howclose = 5f;

    [SerializeField] public float Boomerhealth;
    [SerializeField] public bool isDead;

    public AudioSource audio;
    private void Start()
    {
        
        zombie = transform.gameObject;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        howclose = 20f; //20f
        Boomerhealth = 25; //25
        agent.speed = 2;
        anim = GetComponentInChildren<Animator>();

        audio = GameObject.FindGameObjectWithTag("Explosion").GetComponent<AudioSource>();
    }

    private void Update()
    {


        GoToTarget();

        if (isDead)
        {
            explosion.transform.position = zombie.transform.position;
            explosion.Play();
            audio.Play();
            if (distance < 5f) 
            {
                target.GetComponent<CharacterStats>().TakeDamage(50);
            }

            GameObject.Destroy(zombie, 0);
        }

    }

    private void GoToTarget()
    {

        distance = Vector3.Distance(target.transform.position, transform.position);
        // this is how you influence the speed variable for the navmesh: agent.speed = 2;
        // use this to change it based on what zombie the script is managing

        if (distance <= 4.5f)
        {
            agent.isStopped = true;
            Attack(50);

        }
        else if (distance <= howclose)
        {
            agent.isStopped = false;
            anim.SetInteger("walking", 1);
            agent.SetDestination(target.transform.position);

        }
        else
        {
            agent.isStopped = true;
            anim.SetInteger("walking", 0);
        }

    }

    private void Attack(int damage)
    {
        if (Time.time - lastAttackTime >= attackCoolDown)
        {
            explosion.transform.position = zombie.transform.position;
            explosion.Play();
            audio.Play();
            target.GetComponent<CharacterStats>().TakeDamage(damage);
            target.GetComponent<CharacterStats>().CheckHealth();
            GameObject.Destroy(zombie,0);
         

        }
     

    }

    public void TakeDamage(float damage)
    {
        Boomerhealth -= damage;
        if (Boomerhealth <= 0)
        {
            isDead = true;
           

        }
    }

}
