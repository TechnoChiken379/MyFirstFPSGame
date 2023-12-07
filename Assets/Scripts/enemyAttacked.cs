using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class enemyAttacked : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private Transform player;
    public float attackRange = 10f;

    public Material defaultMaterial;
    public Material attackedMaterial;
    private Renderer rend;
    public NavMeshAgent navMeshAgent;
    private bool canMove;

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
        if(Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            rend.sharedMaterial = attackedMaterial;
            enemyMovement.agent.SetDestination(player.position);
            canMove = true;
            navMeshAgent.speed = 7f;
        }
        else
        {
            rend.sharedMaterial = defaultMaterial;
            if (canMove)
            {
                enemyMovement.newLocation();
            }
            canMove = false;
            navMeshAgent.speed = 4.5f;
        }
    }
}
