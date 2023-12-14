using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHotKeys : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject AK;
    public GameObject Sniper;
    public GameObject GumGun;
    public GameObject EpicGun;
    public GameObject Grenade;

    void Start()
    {
        Pistol.SetActive(true);
        AK.SetActive(false);
        Sniper.SetActive(false);
        GumGun.SetActive(false);
        EpicGun.SetActive(false);
        Grenade.SetActive(false);
    }

    void Update()
    {
        hotkeys();
    }

    public void hotkeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Pistol.SetActive(true);
            AK.SetActive(false);
            Sniper.SetActive(false);
            GumGun.SetActive(false);
            EpicGun.SetActive(false);
            Grenade.SetActive(false);
        }
       
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Pistol.SetActive(false);
            AK.SetActive(true);
            Sniper.SetActive(false);
            GumGun.SetActive(false);
            EpicGun.SetActive(false);
            Grenade.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            Pistol.SetActive(false);
            AK.SetActive(false);
            Sniper.SetActive(true);
            GumGun.SetActive(false);
            EpicGun.SetActive(false);
            Grenade.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            Pistol.SetActive(false);
            AK.SetActive(false);
            Sniper.SetActive(false);
            GumGun.SetActive(true);
            EpicGun.SetActive(false);
            Grenade.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            Pistol.SetActive(false);
            AK.SetActive(false);
            Sniper.SetActive(false);
            GumGun.SetActive(false);
            EpicGun.SetActive(true);
            Grenade.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha6))
        {
            Pistol.SetActive(false);
            AK.SetActive(false);
            Sniper.SetActive(false);
            GumGun.SetActive(false);
            EpicGun.SetActive(false);
            Grenade.SetActive(true);
        }
    }
}
