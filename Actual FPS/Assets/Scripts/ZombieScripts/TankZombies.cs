using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankZombies : MonoBehaviour
{  // Start is called before the first frame update

    NavMeshAgent agent;
    GameObject target;
    GameObject zombie;

    Animator anim;

    float lastAttackTime = 0f;
    float attackCoolDown = 2f;

    private float distance;
    public float howclose = 5f;

    [SerializeField] public float Tankhealth;
    [SerializeField] public bool isDead;

    public AudioSource audio;
    private void Start()
    {
        zombie = transform.gameObject;
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        howclose = 20f;
        anim = GetComponentInChildren<Animator>();
        agent.speed = 4.5f;
        Tankhealth = 200;

        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {


        GoToTarget();

        if (isDead) 
        {
            GameObject.Destroy(zombie,0);
        }

    }

    private void GoToTarget()
    {

        distance = Vector3.Distance(target.transform.position, transform.position);
        // this is how you influence the speed variable for the navmesh: agent.speed = 2;
        // use this to change it based on what zombie the script is managing

        if (distance <= 3.5f)
        {
            agent.isStopped = true;
            Attack(20);

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
            lastAttackTime = Time.time;
            anim.SetTrigger("attack");
            audio.Play();
            target.GetComponent<CharacterStats>().TakeDamage(damage);
            target.GetComponent<CharacterStats>().CheckHealth();
            anim.SetInteger("walking", 0);
        }

    }

    public void TakeDamage(float damage)
    {
        Tankhealth -= damage;
        if (Tankhealth <= 0)
        {
            isDead = true;
        }
    }

}
