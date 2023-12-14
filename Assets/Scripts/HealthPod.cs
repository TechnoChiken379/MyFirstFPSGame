using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPod : MonoBehaviour
{
    public playerMovement playerMovement;

    void OnCollisionEnter(Collision collisioninfo)
    {
        playerMovement.healthPointsAmount += 50;
        Destroy(gameObject);
    }
}
