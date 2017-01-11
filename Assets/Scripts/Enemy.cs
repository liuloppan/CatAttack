using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int playerDamage = 100;
    public float timeBetweenAttacks = 0.5f;
    float timer;


    public float distanceToPlayer;
    public float noticePlayerDistance = 10.0f;
    public float attackRange = 1.0f;
    public float attackSpeed = 5.0f;
    public float enemyMoveSpeed = 1.0f;
    public float turnSpeed = 3.0f;

    public GameObject player;
    PlayerHealth playerHealth;
    NavMeshAgent catEnemyAgent;


    Rigidbody rb;
    Animator animator;

    bool stateWalk = false;
    bool stateAttack = false;

    AudioSource hissAudio;
    public AudioClip attackSound;
    bool playSound = true;
    float soundTimer = 0.0f;
    public float timeBetweenAttackSound = 3.0f;



    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        hissAudio = GetComponent<AudioSource>();
        catEnemyAgent = GetComponent<NavMeshAgent>();


        // attackSound = GetComponent<AudioClip>();





    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        timer += Time.deltaTime;
        soundTimer += Time.deltaTime;

        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if ((distanceToPlayer < noticePlayerDistance) && !playerHealth.isDead )
        {
            stateWalk = true;
            //LookAtPlayer();
            Invoke("MoveTowardsPlayer", 0.3f);

        }
        else
        {
            //animator.SetBool("IsWalking", false);
            stateWalk = false;
            catEnemyAgent.Stop();



        }
        if (catEnemyAgent.remainingDistance <= attackRange)  //(distanceToPlayer <= attackRange)

        {

            //animator.SetBool("Attack", true);
            stateAttack = true;

        }
        else
        {
            //animator.SetBool("Attack", false);
            stateAttack = false;


        }

        
        AnimatorUpdate();


    }

    void AnimatorUpdate()
    {
        animator.SetBool("IsWalking", stateWalk);
        animator.SetBool("Attack", stateAttack);
        animator.SetBool("PlayerIsDead", playerHealth.isDead);




    }

    /*void LookAtPlayer()
    {
        Quaternion rotateToPlayer = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateToPlayer, turnSpeed);
        MoveTowardsPlayer();



    }*/

    void MoveTowardsPlayer()
    {
        // if (!playerHealth.isDead)
        //transform.position += transform.forward * enemyMoveSpeed * Time.deltaTime;
        catEnemyAgent.SetDestination(player.transform.position);

        catEnemyAgent.Resume();




    }


    void OnCollisionEnter(Collision col)
    {
        if(stateAttack && col.collider.tag == "Player" && timer >= timeBetweenAttacks)
        {

            ApplyDamage(playerDamage);

        }
    }




    void OnCollisionStay(Collision col)
    {
        if (stateAttack && col.collider.tag == "Player" && timer >= timeBetweenAttacks)
        {
            ApplyDamage(playerDamage);
        }

    }

    void ApplyDamage(int damage)
    {
        timer = 0.0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(damage);
            if (playSound)
            {
                soundTimer = 0.0f;
                playSound = false;
                hissAudio.clip = attackSound;

                // hissAudio.PlayOneShot(attackSound);
                hissAudio.Play();

            }

            if (soundTimer > timeBetweenAttackSound)
            {
                playSound = true;

            }
        }

    }





}
