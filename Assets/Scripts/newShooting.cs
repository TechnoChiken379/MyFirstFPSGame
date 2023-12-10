using UnityEngine;

public class newShooting : MonoBehaviour
{
    #region variables
    // References to game objects and positions
    public GameObject bullet;
    public GameObject Pistol;
    public Transform bulletSpawnPoint;
    public float fireSpeed = 250;

    // Timer variables for controlling firing rate
    public float timer = 0f;
    public float canFire = 0.2f;

    // Gun positions for different states
    private Vector3 originalGunPosition;
    private Vector3 newGunPosition;
    private Vector3 aimGunPosition = new Vector3(0, -0.075f, 0.855f);
    private Vector3 aimGunPositionOnDS = new Vector3(0, -0.150f, 0.855f);

    // AK positions for different states
    private Vector3 originalAKPosition;
    private Vector3 newAKPosition;
    private Vector3 aimAKPosition = new Vector3(0, -0.1f, 1.92f);
    private Vector3 aimAKPositionOnDS = new Vector3(0, -0.2f, 1.92f);

    // Sniper positions for different states
    private Vector3 originalSniperPosition;
    private Vector3 newSniperPosition;
    private Vector3 aimSniperPosition = new Vector3(0, -0.17f, -0.2f);
    private Vector3 aimSniperPositionOnDS = new Vector3(0, -0.34f, -0.2f);

    // GumGun positions for different states
    private Vector3 originalGumGunPosition;
    private Vector3 newGumGunPosition;
    private Vector3 aimGumGunPosition = new Vector3(0, -0.075f, 0.855f);
    private Vector3 aimGumGunPositionOnDS = new Vector3(0, -0.150f, 0.855f);

    // Hotkey variables to manage different weapons
    private bool hotKey1;
    private bool hotKey2;
    private bool hotKey3;
    private bool hotKey4;
    #endregion

    void Start()
    {
        // Initialization of gun positions
        newGunPosition = transform.localPosition;
        originalGunPosition = newGunPosition;

        newAKPosition = transform.localPosition;
        originalAKPosition = newAKPosition;

        newSniperPosition = transform.localPosition;
        originalSniperPosition = newSniperPosition;

        newGumGunPosition = transform.localPosition;
        originalGumGunPosition = newGumGunPosition;
    }

    void Update()
    {
        // Update timer for firing rate control
        timer += Time.deltaTime;

        // Manage hotkeys and fire bullets
        HotKeyManagment();
        FireBullet();
    }

    public void FireBullet() // Fire Bullet Script
    {
        // Fire bullet when left mouse button is pressed and cooldown is met
        if (Input.GetMouseButton(0) && timer >= canFire)
        {
            // Instantiate a bullet and set its velocity
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.right * fireSpeed;
            Destroy(spawnedBullet, 2); // Destroy the bullet after 2 seconds
            timer = 0f; // Reset the firing timer
        }

        // Handle aiming positions based on right mouse button and hotkeys
        if (Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftControl))
        {
            // Update gun position based on the selected hotkey
            if (hotKey1 == true)
            {
                newGunPosition = aimGunPosition;
                transform.localPosition = aimGunPosition;
            }
            else if (hotKey2 == true)
            {
                newAKPosition = aimAKPosition;
                transform.localPosition = aimAKPosition;
            }
            else if (hotKey3 == true)
            {
                newSniperPosition = aimSniperPosition;
                transform.localPosition = aimSniperPosition;
            }
            else if (hotKey4 == true)
            {
                newGumGunPosition = aimGumGunPosition;
                transform.localPosition = aimGumGunPosition;
            }
        }
        // Handle returning to original positions when not aiming
        else if (!Input.GetMouseButton(1) && !Input.GetKey(KeyCode.LeftControl))
        {
            // Update gun position based on the selected hotkey
            if (hotKey1 == false)
            {
                newGunPosition = originalGunPosition;
                transform.localPosition = newGunPosition;
            }
            else if (hotKey2 == false)
            {
                newAKPosition = originalAKPosition;
                transform.localPosition = newAKPosition;
            }
            else if (hotKey3 == false)
            {
                newSniperPosition = originalSniperPosition;
                transform.localPosition = newSniperPosition;
            }
            else if (hotKey4 == false)
            {
                newGumGunPosition = originalGumGunPosition;
                transform.localPosition = newGumGunPosition;
            }
        }
        // Handle aiming positions on left control key press
        else if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftControl))
        {
            // Update gun position based on the selected hotkey
            if (hotKey1 == true)
            {
                newGunPosition = aimGunPositionOnDS;
                transform.localPosition = aimGunPositionOnDS;
            }
            else if (hotKey2 == true)
            {
                newAKPosition = aimAKPositionOnDS;
                transform.localPosition = aimAKPositionOnDS;
            }
            else if (hotKey3 == true)
            {
                newSniperPosition = aimSniperPositionOnDS;
                transform.localPosition = aimSniperPositionOnDS;
            }
            else if (hotKey4 == true)
            {
                newGumGunPosition = aimGumGunPositionOnDS;
                transform.localPosition = aimGumGunPositionOnDS;
            }
        }
        // Handle returning to original positions when not aiming on left control key press
        else if (!Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftControl))
        {
            // Update gun position based on the selected hotkey
            if (hotKey1 == false)
            {
                newGunPosition = originalGunPosition;
                transform.localPosition = newGunPosition;
            }
            else if (hotKey2 == false)
            {
                newAKPosition = originalAKPosition;
                transform.localPosition = newAKPosition;
            }
            else if (hotKey3 == false)
            {
                newSniperPosition = originalSniperPosition;
                transform.localPosition = newSniperPosition;
            }
            else if (hotKey4 == false)
            {
                newGumGunPosition = originalGumGunPosition;
                transform.localPosition = newGumGunPosition;
            }
        }
    }

    public void HotKeyManagment()
    {
        // Check for hotkey presses and update hotKey variables
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            hotKey1 = true;
            hotKey2 = false;
            hotKey3 = false;
            hotKey4 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hotKey1 = false;
            hotKey2 = true;
            hotKey3 = false;
            hotKey4 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hotKey1 = false;
            hotKey2 = false;
            hotKey3 = true;
            hotKey4 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            hotKey1 = false;
            hotKey2 = false;
            hotKey3 = false;
            hotKey4 = true;
        }
    }
}