using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject bulletGrenade;
    public float squareOffMovement = 50f;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;
    private float xPosistion;
    private float zPosistion;
    private float yPosistion;
    public float closeEnough = 50f;
    public static float enemyHP = 20f;
    public static int damageAmount = 3;

    private GameObject Body;
    private float range = 10;
    // Start is called before the first frame update
    void Start()
    {
        Body = GameObject.Find("Body");
        xMax = -squareOffMovement;
        xMin = squareOffMovement;
        zMax = -squareOffMovement;
        zMin = squareOffMovement;

        playerRange();
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
    public void DamageDealt()
    {
        enemyHP -= damageAmount;

        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void playerRange()
    {
        if (Vector3.Distance(transform.position, Body.transform.position) <= range)
        {

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<SphereCollider>(out SphereCollider Radius))
        {
            Debug.Log("spherecollider");
            enemyHP = 0;
        }
    }
}
