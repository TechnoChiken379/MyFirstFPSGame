using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public NavMeshAgent agent;
    public float squareOffMovement = 50f;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;
    private float xPosistion;
    private float zPosistion;
    private float yPosistion;
    public float closeEnough = 2f;
    private float enemyHP = 10f;

    // Start is called before the first frame update
    void Start()
    {
        xMax = -squareOffMovement;
        xMin = squareOffMovement;
        zMax = -squareOffMovement;
        zMin = squareOffMovement;

        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, new Vector3(xPosistion, yPosistion, zPosistion)) <= closeEnough)
        {
            newLocation();
        }
    }

    public void newLocation()
    {
        yPosistion = transform.position.y;
        xPosistion = Random.Range(xMin, xMax);
        zPosistion = Random.Range(zMin, zMax);

        agent.SetDestination(new Vector3(xPosistion, yPosistion, zPosistion));
    }

    public void DamageDealt(float damageAmount)
    {
        enemyHP -= damageAmount;

        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
