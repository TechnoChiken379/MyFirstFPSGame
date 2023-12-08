using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHotKeys : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject AK;
    public GameObject Sniper;
    public GameObject GumGun;

    void Start()
    {
        Pistol.SetActive(true);
        AK.SetActive(false);
        Sniper.SetActive(false);
        GumGun.SetActive(false);
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
        }
       
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Pistol.SetActive(false);
            AK.SetActive(true);
            Sniper.SetActive(false);
            GumGun.SetActive(false);
        }

        if (Input.GetKey("3"))
        {
            Pistol.SetActive(false);
            AK.SetActive(false);
            Sniper.SetActive(true);
            GumGun.SetActive(false);
        }

        if (Input.GetKey("4"))
        {
            Pistol.SetActive(false);
            AK.SetActive(false);
            Sniper.SetActive(false);
            GumGun.SetActive(true);
        }

    }

    //public void GetPistol()
    //{
    //    //Vector3 spawnPosition = new Vector3(0.651f, -0.276f, 1.281f);
    //    //Quaternion spawnRotation = Quaternion.identity;
    //    //GameObject instantiatedPrefab = Instantiate(PistolPrefab/*, spawnPosition, spawnRotation*/);
    //}
    //public void GetAK()
    //{
    //    Vector3 spawnPosition = new Vector3(0, 0, 0);
    //    Quaternion spawnRotation = Quaternion.identity;
    //    //GameObject instantiatedPrefab = Instantiate(AKPrefab, spawnPosition, spawnRotation);
    //}
    ////public void GetSniper()
    ////{
    ////    Vector3 spawnPosition = new Vector3(0, 0, 0);
    ////    Quaternion spawnRotation = Quaternion.identity;
    ////    GameObject instantiatedPrefab = Instantiate(SniperPrefab, spawnPosition, spawnRotation);
    ////}
    ////public void GetGumGun()
    ////{
    ////    Vector3 spawnPosition = new Vector3(0, 0, 0);
    ////    Quaternion spawnRotation = Quaternion.identity;
    ////    GameObject instantiatedPrefab = Instantiate(GumGunPrefab, spawnPosition, spawnRotation);
    ////}
}
