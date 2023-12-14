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
    private Vector3 aimGunPositionOnDS = new Vector3(0, -0.075f, 0.855f);
    [SerializeField] public static int gunMaxAmmo = 16;
    [SerializeField] public static int gunCurrentAmmo;
    [SerializeField] public static int gunBackUpAmmoAmount;
    [SerializeField] public static float gunTimer;
    [SerializeField] public static float gunMaxTimer = 2.5f;

    // AK positions for different states
    private Vector3 originalAKPosition;
    private Vector3 newAKPosition;
    private Vector3 aimAKPosition = new Vector3(0, -0.1f, 1.92f);
    private Vector3 aimAKPositionOnDS = new Vector3(0, -0.1f, 1.92f);
    [SerializeField] public static int aKMaxAmmo = 36;
    [SerializeField] public static int aKCurrentAmmo;
    [SerializeField] public static int aKBackUpAmmoAmount;
    [SerializeField] public static float aKTimer;
    [SerializeField] public static float aKMaxTimer = 3.5f;

    // Sniper positions for different states
    private Vector3 originalSniperPosition;
    private Vector3 newSniperPosition;
    private Vector3 aimSniperPosition = new Vector3(0, -0.2f, -1.7f);
    private Vector3 aimSniperPositionOnDS = new Vector3(0, -0.2f, -1.7f);
    [SerializeField] public static int sniperMaxAmmo = 10;
    [SerializeField] public static int sniperCurrentAmmo;
    [SerializeField] public static int sniperBackUpAmmoAmount;
    [SerializeField] public static float sniperTimer;
    [SerializeField] public static float sniperMaxTimer = 5f;

    // GumGun positions for different states
    private Vector3 originalGumGunPosition;
    private Vector3 newGumGunPosition;
    private Vector3 aimGumGunPosition = new Vector3(0, -0.075f, 0.855f);
    private Vector3 aimGumGunPositionOnDS = new Vector3(0, -0.075f, 0.855f);
    [SerializeField] public static int gumGunMaxAmmo = 69;
    [SerializeField] public static int gumGunCurrentAmmo;
    [SerializeField] public static int gumGunBackUpAmmoAmount;
    [SerializeField] public static float gumGunTimer;
    [SerializeField] public static float gumGunMaxTimer = 7f;

    // EpicGun positions for different states
    private Vector3 originalEpicGunPosition;
    private Vector3 newEpicGunPosition;
    private Vector3 aimEpicGunPosition = new Vector3(0, -0.075f, 0.855f);
    private Vector3 aimEpicGunPositionOnDS = new Vector3(0, -0.075f, 0.855f);
    [SerializeField] public static int epicGunMaxAmmo = 32;
    [SerializeField] public static int epicGunCurrentAmmo;
    [SerializeField] public static int epicGunBackUpAmmoAmount;
    [SerializeField] public static float epicGunTimer;
    [SerializeField] public static float epicGunMaxTimer = 6f;

    // GumGun positions for different states
    private Vector3 originalGrenadePosition;
    private Vector3 newGrenadePosition;
    private Vector3 aimGrenadePosition = new Vector3(0, -0.075f, 0.855f);
    private Vector3 aimGrenadePositionOnDS = new Vector3(0, -0.075f, 0.855f);
    [SerializeField] public static int grenadeMaxAmmo = 1;
    [SerializeField] public static int grenadeCurrentAmmo;
    [SerializeField] public static int grenadeBackUpAmmoAmount;
    [SerializeField] public static float grenadeTimer;
    [SerializeField] public static float grenadeMaxTimer = 4f;

    // Hotkey variables to manage different weapons
    private bool hotKey1;
    private bool hotKey2;
    private bool hotKey3;
    private bool hotKey4;
    private bool hotKey5;
    private bool hotKey6;
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


        gunCurrentAmmo = gunMaxAmmo;
        gunBackUpAmmoAmount = gunMaxAmmo;

        aKCurrentAmmo = aKMaxAmmo;
        aKBackUpAmmoAmount = aKMaxAmmo;

        sniperCurrentAmmo = sniperMaxAmmo;
        sniperBackUpAmmoAmount = sniperMaxAmmo;

        gumGunCurrentAmmo = gumGunMaxAmmo;
        gumGunBackUpAmmoAmount = gumGunMaxAmmo;

        epicGunCurrentAmmo = epicGunMaxAmmo;
        epicGunBackUpAmmoAmount = epicGunMaxAmmo;

        grenadeCurrentAmmo = grenadeMaxAmmo;
        grenadeBackUpAmmoAmount = grenadeMaxAmmo;
    }

    void Update()
    {
        // Update timer for firing rate control
        timer += Time.deltaTime;

        gunTimer += Time.deltaTime;

        aKTimer += Time.deltaTime;

        sniperTimer += Time.deltaTime;

        gumGunTimer += Time.deltaTime;

        epicGunTimer += Time.deltaTime;

        grenadeTimer += Time.deltaTime;

        // Manage hotkeys and fire bullets

        HotKeyManagment();
        AmmoAmountStorage();
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

            gunTimer = 0f;

            aKTimer = 0f;

            sniperTimer = 0f;

            gumGunTimer = 0f;

            epicGunTimer = 0f;

            grenadeTimer = 0f;
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
            else if (hotKey5 == true)
            {
                newEpicGunPosition = aimEpicGunPosition;
                transform.localPosition = aimEpicGunPosition;
            }
            else if (hotKey6 == true)
            {
                newGrenadePosition = aimGrenadePosition;
                transform.localPosition = aimGrenadePosition;
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
            else if (hotKey5 == false)
            {
                newEpicGunPosition = originalEpicGunPosition;
                transform.localPosition = newEpicGunPosition;
            }
            else if (hotKey6 == false)
            {
                newGrenadePosition = originalGrenadePosition;
                transform.localPosition = newGrenadePosition;
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
            else if (hotKey5 == true)
            {
                newEpicGunPosition = aimEpicGunPositionOnDS;
                transform.localPosition = aimEpicGunPositionOnDS;
            }
            else if (hotKey6 == true)
            {
                newGrenadePosition = aimGrenadePositionOnDS;
                transform.localPosition = aimGrenadePositionOnDS;
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
            else if (hotKey5 == false)
            {
                newEpicGunPosition = originalEpicGunPosition;
                transform.localPosition = newEpicGunPosition;
            }
            else if (hotKey6 == false)
            {
                newGrenadePosition = originalGrenadePosition;
                transform.localPosition = newGrenadePosition;
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
            hotKey5 = false;
            hotKey6 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hotKey1 = false;
            hotKey2 = true;
            hotKey3 = false;
            hotKey4 = false;
            hotKey5 = false;
            hotKey6 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hotKey1 = false;
            hotKey2 = false;
            hotKey3 = true;
            hotKey4 = false;
            hotKey5 = false;
            hotKey6 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            hotKey1 = false;
            hotKey2 = false;
            hotKey3 = false;
            hotKey4 = true;
            hotKey5 = false;
            hotKey6 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            hotKey1 = false;
            hotKey2 = false;
            hotKey3 = false;
            hotKey4 = false;
            hotKey5 = true;
            hotKey6 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            hotKey1 = false;
            hotKey2 = false;
            hotKey3 = false;
            hotKey4 = false;
            hotKey5 = false;
            hotKey6 = true;
        }
    }

    public void AmmoAmountStorage()
    {
        if (hotKey1 == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (gunCurrentAmmo >= 1)
            {
                FireBullet();
                gunCurrentAmmo -= 1;
                gunTimer = 0;
            }
            if (gunCurrentAmmo <= 0 && gunTimer >= gunMaxTimer)
            {
                gunCurrentAmmo = gunMaxAmmo;
            }
        }
        if (hotKey1 == false)
        {
            gunBackUpAmmoAmount = gunCurrentAmmo;
        }

        if (hotKey2 == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (aKCurrentAmmo >= 1)
            {
                FireBullet();
                aKCurrentAmmo -= 1;
                aKTimer = 0;
            }
            if (aKCurrentAmmo <= 0 && aKTimer >= aKMaxTimer)
            {
                aKCurrentAmmo = aKMaxAmmo;
            }
        }
        if (hotKey2 == false)
        {
            aKBackUpAmmoAmount = aKCurrentAmmo;
        }

        if (hotKey3 == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (sniperCurrentAmmo >= 1)
            {
                FireBullet();
                sniperCurrentAmmo -= 1;
                sniperTimer = 0;
            }
            if (sniperCurrentAmmo <= 0 && sniperTimer >= sniperMaxTimer)
            {
                sniperCurrentAmmo = sniperMaxAmmo;
            }
        }
        if (hotKey3 == false)
        {
            sniperBackUpAmmoAmount = sniperCurrentAmmo;
        }

        if (hotKey4 == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (gumGunCurrentAmmo >= 1)
            {
                FireBullet();
                gumGunCurrentAmmo -= 1;
                gumGunTimer = 0;
            }
            if (gumGunCurrentAmmo <= 0 && gumGunTimer >= gumGunMaxTimer)
            {
                gumGunCurrentAmmo = gumGunMaxAmmo;
            }
        }
        if (hotKey4 == false)
        {
            gumGunBackUpAmmoAmount = gumGunCurrentAmmo;
        }

        if (hotKey5 == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (epicGunCurrentAmmo >= 1)
            {
                FireBullet();
                epicGunCurrentAmmo -= 1;
                epicGunTimer = 0;
            }
            if (epicGunCurrentAmmo <= 0 && epicGunTimer >= epicGunMaxTimer)
            {
                epicGunCurrentAmmo = epicGunMaxAmmo;
            }
        }
        if (hotKey5 == false)
        {
            epicGunBackUpAmmoAmount = epicGunCurrentAmmo;
        }

        if (hotKey6 == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (grenadeCurrentAmmo >= 1)
            {
                FireBullet();
                grenadeCurrentAmmo -= 1;
                grenadeTimer = 0;
            }
            if (grenadeCurrentAmmo <= 0 && grenadeTimer >= grenadeMaxTimer)
            {
                grenadeCurrentAmmo = grenadeMaxAmmo;
            }
        }
        if (hotKey6 == false)
        {
            grenadeBackUpAmmoAmount = grenadeCurrentAmmo;
        }
    }
}