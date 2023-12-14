using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamageScript : MonoBehaviour
{
    public playerMovement playerMovement;
    public GameObject bullet;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerMovement.healthPointsAmount -= EnemyMovement.damageAmount;
            playerMovement.healthTimer = 0f;

            Destroy(bullet);
        }
    }
}
