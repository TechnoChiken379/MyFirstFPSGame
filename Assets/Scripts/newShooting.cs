using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class newShooting : MonoBehaviour
{
    #region Vars
    public GameObject bullet;
    public GameObject Pistol;
    public Transform bulletSpawnPoint;
    public float fireSpeed = 250;

    public float timer = 0f;
    public float canFire = 0.2f;

    private Vector3 offHandGunPosition;
    private Vector3 newGunPosition;
    private Vector3 aimGunPosition = new Vector3(0, -0.075f, 0.855f);
    private Vector3 aimGunPositionOnDS = new Vector3(0, -0.150f, 0.855f);
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
            Destroy(spawnedBullet, 2);
            timer = 0f;
        }

        if (Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftControl))
        {
            newGunPosition = aimGunPosition;
            transform.localPosition = aimGunPosition;
        }

        else if (!Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftControl))
        {
            newGunPosition = offHandGunPosition;
            transform.localPosition = offHandGunPosition;
        }

        else if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftControl))
        {
            newGunPosition = aimGunPositionOnDS;
            transform.localPosition = aimGunPositionOnDS;
        }

        else if (!Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftControl))
        {
            newGunPosition = offHandGunPosition;
            transform.localPosition = offHandGunPosition;
        }
    }
}
