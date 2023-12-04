using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageScript : MonoBehaviour
{
    public GameObject enemy;
    public static float damageAmount = 2.5f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyMovement>(out EnemyMovement Enemy))
        {
            Enemy.DamageDealt(1);
        }
    }
}
