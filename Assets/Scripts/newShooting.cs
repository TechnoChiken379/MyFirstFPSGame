using Unity.VisualScripting;
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
    public bool isReloading = false;

    // Gun positions for different states
    private Vector3 originalGunPosition;
    private Vector3 newGunPosition;
    private Vector3 aimGunPosition = new Vector3(0, -0.075f, 0.855f);
    private Vector3 aimGunPositionOnDS = new Vector3(0, -0.075f, 0.855f);
    [SerializeField] public static int gunMaxAmmo = 16;
    [SerializeField] public static int gunCurrentAmmo;
    [SerializeField] public static int gunBackUpAmmoAmount;
    [SerializeField] public static float gunFireRate = 0.2f;
    [SerializeField] public static float gunReloadTime = 2.5f;

    // AK positions for different states
    private Vector3 originalAKPosition;
    private Vector3 newAKPosition;
    private Vector3 aimAKPosition = new Vector3(0, -0.1f, 1.92f);
    private Vector3 aimAKPositionOnDS = new Vector3(0, -0.1f, 1.92f);
    [SerializeField] public static int aKMaxAmmo = 36;
    [SerializeField] public static int aKCurrentAmmo;
    [SerializeField] public static int aKBackUpAmmoAmount;
    [SerializeField] public static float aKFireRate = 0.08f;
    [SerializeField] public static float aKReloadTime = 3.5f;

    // Sniper positions for different states
    private Vector3 originalSniperPosition;
    private Vector3 newSniperPosition;
    private Vector3 aimSniperPosition = new Vector3(0, -0.2f, -1.7f);
    private Vector3 aimSniperPositionOnDS = new Vector3(0, -0.2f, -1.7f);
    [SerializeField] public static int sniperMaxAmmo = 10;
    [SerializeField] public static int sniperCurrentAmmo;
    [SerializeField] public static int sniperBackUpAmmoAmount;
    [SerializeField] public static float sniperFireRate = 2f;
    [SerializeField] public static float sniperReloadTime = 5f;

    // GumGun positions for different states
    private Vector3 originalGumGunPosition;
    private Vector3 newGumGunPosition;
    private Vector3 aimGumGunPosition = new Vector3(0, -0.075f, 0.855f);
    private Vector3 aimGumGunPositionOnDS = new Vector3(0, -0.075f, 0.855f);
    [SerializeField] public static int gumGunMaxAmmo = 69;
    [SerializeField] public static int gumGunCurrentAmmo;
    [SerializeField] public static int gumGunBackUpAmmoAmount;
    [SerializeField] public static float gumGunFireRate = 0.05f;
    [SerializeField] public static float gumGunReloadTime = 7f;

    // EpicGun positions for different states
    private Vector3 originalEpicGunPosition;
    private Vector3 newEpicGunPosition;
    private Vector3 aimEpicGunPosition = new Vector3(0, -0.075f, 0.855f);
    private Vector3 aimEpicGunPositionOnDS = new Vector3(0, -0.075f, 0.855f);
    [SerializeField] public static int epicGunMaxAmmo = 32;
    [SerializeField] public static int epicGunCurrentAmmo;
    [SerializeField] public static int epicGunBackUpAmmoAmount;
    [SerializeField] public static float epicGunFireRate = 0.35f;
    [SerializeField] public static float epicGunReloadTime = 6f;

    // GumGun positions for different states
    private Vector3 originalGrenadePosition;
    private Vector3 newGrenadePosition;
    private Vector3 aimGrenadePosition = new Vector3(0, -0.075f, 0.855f);
    private Vector3 aimGrenadePositionOnDS = new Vector3(0, -0.075f, 0.855f);
    [SerializeField] public static int grenadeMaxAmmo = 1;
    [SerializeField] public static int grenadeCurrentAmmo;
    [SerializeField] public static int grenadeBackUpAmmoAmount;
    [SerializeField] public static float grenadeFireRate = 4f;
    [SerializeField] public static float grenadeReloadTime = 4f;

    // Hotkey variables to manage different weapons
    public bool hotKey1;
    public bool hotKey2;
    public bool hotKey3;
    public bool hotKey4;
    public bool hotKey5;
    public bool hotKey6;

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

        hotKey1 = true;
        hotKey2 = false;
        hotKey3 = false;
        hotKey4 = false;
        hotKey5 = false;
        hotKey6 = false;

        HotKeyManagment();
    }

    void Update()
    {
        // Update timer for firing rate control
        timer += Time.deltaTime;

        // Manage hotkeys and fire bullets

        FireBullet();
        HotKeyManagment();
    }

    public void FireBullet() // Fire Bullet Script
    {
        if (isReloading)
        {   
            if(timer >= canFire)
            {
                ReloadGun();
            }
        }
        // Fire bullet when left mouse button is pressed and cooldown is met
        else if (Input.GetMouseButton(0) && timer >= canFire)
        {
            // Instantiate a bullet and set its velocity
            GameObject spawnedBullet = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.right * fireSpeed;
            Destroy(spawnedBullet, 2); // Destroy the bullet after 2 seconds
            timer = 0f; // Reset the firing timer
            AmmoAmountStorage();
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
            BackupAmmo();
            hotKey1 = true;
            hotKey2 = false;
            hotKey3 = false;
            hotKey4 = false;
            hotKey5 = false;
            hotKey6 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BackupAmmo();
            hotKey1 = false;
            hotKey2 = true;
            hotKey3 = false;
            hotKey4 = false;
            hotKey5 = false;
            hotKey6 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BackupAmmo();
            hotKey1 = false;
            hotKey2 = false;
            hotKey3 = true;
            hotKey4 = false;
            hotKey5 = false;
            hotKey6 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            BackupAmmo();
            hotKey1 = false;
            hotKey2 = false;
            hotKey3 = false;
            hotKey4 = true;
            hotKey5 = false;
            hotKey6 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            BackupAmmo();
            hotKey1 = false;
            hotKey2 = false;
            hotKey3 = false;
            hotKey4 = false;
            hotKey5 = true;
            hotKey6 = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            BackupAmmo();
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
        
        // check if weapon is equiped
        if (hotKey1 == true)
        {
            // if there's still bullits
            if (gunCurrentAmmo >= 1)
            {
                // reduce bullit
                gunCurrentAmmo -= 1;
                canFire = gunFireRate;
            }
            if (gunCurrentAmmo == 0)
            {
                isReloading = true;
                canFire = gunReloadTime;
            }
        }
        if (hotKey2 == true)
        {
            // if there's still bullits
            if (aKCurrentAmmo >= 1)
            {
                // reduce bullit
                aKCurrentAmmo -= 1;
                canFire = aKFireRate;
            }
            if (aKCurrentAmmo == 0)
            {
                isReloading = true;
                canFire = aKReloadTime;
            }
        }
        if (hotKey3 == true)
        {
            // if there's still bullits
            if (sniperCurrentAmmo >= 1)
            {
                // reduce bullit
                sniperCurrentAmmo -= 1;
                canFire = sniperFireRate;
            }
            if (sniperCurrentAmmo == 0)
            {
                isReloading = true;
                canFire = sniperReloadTime;
            }
        }
        if (hotKey4 == true)
        {
            // if there's still bullits
            if (gumGunCurrentAmmo >= 1)
            {
                // reduce bullit
                gumGunCurrentAmmo -= 1;
                canFire = gumGunFireRate;
            }
            if (gumGunCurrentAmmo == 0)
            {
                isReloading = true;
                canFire = gumGunReloadTime;
            }
        }
        if (hotKey5 == true)
        {
            // if there's still bullits
            if (epicGunCurrentAmmo >= 1)
            {
                // reduce bullit
                epicGunCurrentAmmo -= 1;
                canFire = epicGunFireRate;
            }
            if (epicGunCurrentAmmo == 0)
            {
                isReloading = true;
                canFire = epicGunReloadTime;
            }
        }
        if (hotKey6 == true)
        {
            // if there's still bullits
            if (grenadeCurrentAmmo >= 1)
            {
                // reduce bullit
                grenadeCurrentAmmo -= 1;
                canFire = grenadeFireRate;
            }
            if (grenadeCurrentAmmo == 0)
            {
                isReloading = true;
                canFire = grenadeReloadTime;
            }
        }
    }

    public void BackupAmmo()
    {
        gunBackUpAmmoAmount = gunCurrentAmmo;
        aKBackUpAmmoAmount = aKCurrentAmmo;
        sniperBackUpAmmoAmount = sniperCurrentAmmo;
        gumGunBackUpAmmoAmount = gumGunCurrentAmmo;
        epicGunBackUpAmmoAmount = epicGunCurrentAmmo;
        grenadeBackUpAmmoAmount = grenadeCurrentAmmo;
    }

    public void ReloadGun()
    {
        // check if weapon is equiped
        if (hotKey1 == true)
        {
            isReloading = false;
            gunCurrentAmmo = gunMaxAmmo;
        }
        // check if weapon is equiped
        if (hotKey2 == true)
        {
            isReloading = false;
            aKCurrentAmmo = aKMaxAmmo;
        }
        // check if weapon is equiped
        if (hotKey3 == true)
        {
            isReloading = false;
            sniperCurrentAmmo = sniperMaxAmmo;
        }
        // check if weapon is equiped
        if (hotKey4 == true)
        {
            isReloading = false;
            gumGunCurrentAmmo = gumGunMaxAmmo;
        }
        // check if weapon is equiped
        if (hotKey5 == true)
        {
            isReloading = false;
            epicGunCurrentAmmo = epicGunMaxAmmo;
        }
        // check if weapon is equiped
        if (hotKey6 == true)
        {
            isReloading = false;
            grenadeCurrentAmmo = grenadeMaxAmmo;
        }
    }
}