using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int EnemyAmount;

    void Start()
    {
        GetComponent<EnemySpawner>();
        for (int i = 0; i < EnemyAmount; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefab,transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
