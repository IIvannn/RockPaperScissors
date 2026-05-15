
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.Rendering.UI;

public class EnemyFollow : MonoBehaviour
{
    public Transform firePoint;
    public int attackDamage = 20;
    public float attackCooldown = 0.5f;
    private float lastAttackTime;

    public float chaseSpeed = 6f;
    public float walkSpeed = 3.2f;


    public Transform player;

    public float chaseRange = 5f;
    public float attackRange = 2f;


    NavMeshAgent agent; //reference for the n

    State currentState; //states of the enemy

    public Transform[] patrolPoints; //patrol objects
    int currentPoint = 0; //start from the first patrolling point

    float waitTime = 2f; //amount of time to wait in the patroling point
    float waitCounter; //calculate waiting time

    public Animator animator;
    bool waiting = false;

    

    public int maxHp = 5;
    int hp;

    float nextFireTime;
    public float firerate;
    public int type = 1;
    public bool randomtype = false;
    public GameObject rockProj;
    public GameObject paperProj;
    public GameObject scissorsProj;

    enum State //states of the enemy
    {
        Idle,
        Patrol,
        Chase,
        Attack
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (randomtype)
        {
            type = Random.Range(1, 4);
            Debug.Log(type);

        }

        //if (type == 1)
        //{
        //    rock.SetActive(true);
        //}
        //else if (type == 2)
        //{
        //    paper.SetActive(true);
        //}
        //else if (type == 3)
        //{
        //    scissors.SetActive(true);
        //}


        agent = GetComponent<NavMeshAgent>();

        currentState = State.Idle;

        //start patrolling
        if (patrolPoints.Length > 0) //check if the table is not empty
        {
            agent.SetDestination(patrolPoints[currentPoint].position); //start going to the first patrolling point

        }

        animator = GetComponent<Animator>();
        animator.SetBool("patroling", true);
    }

    // Update is called once per frame
    void Update()
    {
        FireNow();

        float distance = Vector3.Distance(transform.position, player.position); //check the distance between the enemy and the player

        if (distance > chaseRange)
        {
            currentState = State.Idle;
        }
        else if (distance > attackRange)
        {
            currentState = State.Chase;
        }
        else
        {
            currentState = State.Attack;
        }

        HandleState(); //apply states
    }

    void HandleState()
    {
        switch (currentState)
        {
            case State.Idle:
                //Debug.Log("Enemy idle");
                Patrol(); //if here is no player nearby patrol the area
                          //agent.SetDestination(transform.position);

                break;

            case State.Chase:
                //Debug.Log("Enemy chase");
                agent.SetDestination(player.position); //chase the player
                break;

            case State.Attack:
                //Debug.Log("Enemy attacking"); //atack the player
                break;
        }

        if (currentState == State.Chase)
        {
            agent.speed = chaseSpeed;
            animator.SetBool("chasing", true);
        }
        else
        {
            agent.speed = walkSpeed;
            animator.SetBool("chasing", false);
            if (!waiting && currentState == State.Idle)
            {
                animator.SetBool("patroling", true); //set patrolling animation based on chase state
            }
            else if (currentState == State.Idle || currentState == State.Chase)
            {
                animator.SetBool("patroling", currentState == State.Chase); //set patrolling animation based on chase state
            }

            animator.SetBool("attacking", currentState == State.Attack); //set atacking animation based on atack state
        }


    }


    void Patrol()
    {
        if (agent.remainingDistance < 0.5f) //check if we reached the patrolling point
        {

            animator.SetBool("patroling", false); //stop the patroling animation ans start the waiting time
            waiting = true;
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime) //waiting time finished
            {
                currentPoint = (currentPoint + 1) % patrolPoints.Length; //get the next patroling point to go to
                /*if (currentPoint>patrolPoints.Length)
                    currentPoint = 0;*/
                agent.SetDestination(patrolPoints[currentPoint].position); //start going to the next patroling point
                waitCounter = 0f; //reset the waiting time
                animator.SetBool("patroling", true); //play the patrolling animation
                waiting = false;
            }
        }
    }

    void FireNow()
    {
        if (Time.time >= nextFireTime)
        {
            if (type == 1)
            {
                GameObject ball = Instantiate(rockProj, firePoint.position, firePoint.rotation);
            }
            else if (type == 2)
            {
                GameObject ball = Instantiate(paperProj, firePoint.position, firePoint.rotation);
            }
            else if (type == 3)
            {
                GameObject ball = Instantiate(scissorsProj, firePoint.position, firePoint.rotation);
            }
            
            nextFireTime = Time.time + firerate;
        }

    }



}