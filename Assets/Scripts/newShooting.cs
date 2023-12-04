using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class newShooting : MonoBehaviour
{
    #region Vars
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float fireSpeed = 12;

    public float timer = 0f;
    public float canFire = 0.25f;

    private Vector3 offHandGunPosition;
    private Vector3 newGunPosition;
    private Vector3 aimGunPosition = new Vector3(0, -0.129f, 0.641f);
    #endregion
    void Start() // Do this at start
    {
        offHandGunPosition = transform.localPosition;
        newGunPosition = offHandGunPosition;
    }
    void Update() // Update is called once per frame
    {
        timer += Time.deltaTime;
        FireBullet();
    }
    public void FireBullet() // Fire Bullet Script
    {
        if (Input.GetMouseButton(0) && timer >= canFire)
        {
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.right * fireSpeed;
            Destroy(spawnedBullet, 5);
            timer = 0f;
        }
        if (Input.GetMouseButton(1))
        {
            newGunPosition = aimGunPosition;
            transform.localPosition = aimGunPosition;
        }
        else if (!Input.GetMouseButton(1))
        {
            newGunPosition = offHandGunPosition;
            transform.localPosition = offHandGunPosition;
        }

    }
}
