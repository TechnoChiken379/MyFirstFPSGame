using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class enemyAttacked : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private Transform player;
    public float attackRange = 20f;

    public Material defaultMaterial;
    public Material attackedMaterial;
    private Renderer rend;
    public NavMeshAgent navMeshAgent;
    private bool canMove;

    public GameObject enemyBullet;
    public Transform bulletSpawnPoint;
    private float fireSpeed = 100;
    private float fireRange = 18;

    private float timer = 0f;
    private float canFire = 0.3f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<EnemyMovement>();
        rend = GetComponent<Renderer>();
        GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        FireBuller();

        if(Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            rend.sharedMaterial = attackedMaterial;
            enemyMovement.agent.SetDestination(player.position);
            canMove = true;
            navMeshAgent.speed = 8f;
        }
        else
        {
            rend.sharedMaterial = defaultMaterial;
            if (canMove)
            {
                enemyMovement.newLocation();
            }
            canMove = false;
            navMeshAgent.speed = 5.5f;
        }
    }

    private void FireBuller()
    {
        if (Vector3.Distance(transform.position, player.position) <= fireRange && timer >= canFire)
        {
            GameObject spawnedBullet = Instantiate(enemyBullet, bulletSpawnPoint.position, Quaternion.identity);

            Vector3 directionToPlayer = (player.position - bulletSpawnPoint.position).normalized;
            spawnedBullet.GetComponent<Rigidbody>().velocity = directionToPlayer * fireSpeed;

            Destroy(spawnedBullet, 2);
            timer = 0f;
        }
    }
}
