using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class newShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float fireSpeed = 12;

    public float timer = 0f;
    public float canFire = 0.25f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        FireBullet();
    }

    public void FireBullet()
    {
        if (Input.GetMouseButton(0) && timer >= canFire)
        {
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.right * fireSpeed;
            Destroy(spawnedBullet, 2);
            timer = 0f;
        }

    }
}
