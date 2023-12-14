using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    private GameObject AmmoGameObject;
    private TMPro.TMP_Text AmmoAmount;

    public int gunCurrentAmmo;
    public newShooting Pistol;

    public int aKCurrentAmmo;
    public newShooting AK;

    public int sniperCurrentAmmo;
    public newShooting Sniper;

    public int gumGunCurrentAmmo;
    public newShooting GumGun;

    public int epicGunCurrentAmmo;
    public newShooting EpicGun;

    public int grenadeCurrentAmmo;
    public newShooting Grenade;

    private void Start()
    {
        gunCurrentAmmo = newShooting.gunCurrentAmmo;
        AmmoGameObject = GameObject.Find("AmmoAmount");
        AmmoAmount = AmmoGameObject.GetComponent<TMPro.TMP_Text>();

        aKCurrentAmmo = newShooting.aKCurrentAmmo;
        AmmoGameObject = GameObject.Find("AmmoAmount");
        AmmoAmount = AmmoGameObject.GetComponent<TMPro.TMP_Text>();

        sniperCurrentAmmo = newShooting.sniperCurrentAmmo;
        AmmoGameObject = GameObject.Find("AmmoAmount");
        AmmoAmount = AmmoGameObject.GetComponent<TMPro.TMP_Text>();

        gumGunCurrentAmmo = newShooting.gumGunCurrentAmmo;
        AmmoGameObject = GameObject.Find("AmmoAmount");
        AmmoAmount = AmmoGameObject.GetComponent<TMPro.TMP_Text>();

        epicGunCurrentAmmo = newShooting.epicGunCurrentAmmo;
        AmmoGameObject = GameObject.Find("AmmoAmount");
        AmmoAmount = AmmoGameObject.GetComponent<TMPro.TMP_Text>();

        grenadeCurrentAmmo = newShooting.grenadeCurrentAmmo;
        AmmoGameObject = GameObject.Find("AmmoAmount");
        AmmoAmount = AmmoGameObject.GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {
        AmmoShowerPerGun();
    }

    public void AmmoShowerPerGun()
    {
        if (Pistol.hotKey1 == true)
        {
            gunCurrentAmmo = newShooting.gunCurrentAmmo;
            AmmoAmount.text = gunCurrentAmmo.ToString() + " / " + newShooting.gunMaxAmmo.ToString();
        }

        else if (AK.hotKey2 == true)
        {
            aKCurrentAmmo = newShooting.aKCurrentAmmo;
            AmmoAmount.text = aKCurrentAmmo.ToString() + " / " + newShooting.aKMaxAmmo.ToString();
        }

        else if (Sniper.hotKey3 == true)
        {
            sniperCurrentAmmo = newShooting.sniperCurrentAmmo;
            AmmoAmount.text = sniperCurrentAmmo.ToString() + " / " + newShooting.sniperMaxAmmo.ToString();
        }

        else if (GumGun.hotKey4 == true)
        {
            gumGunCurrentAmmo = newShooting.gumGunCurrentAmmo;
            AmmoAmount.text = gumGunCurrentAmmo.ToString() + " / " + newShooting.gumGunMaxAmmo.ToString();
        }

        else if (EpicGun.hotKey5 == true)
        {
            epicGunCurrentAmmo = newShooting.epicGunCurrentAmmo;
            AmmoAmount.text = epicGunCurrentAmmo.ToString() + " / " + newShooting.epicGunMaxAmmo.ToString();
        }

        else if (Grenade.hotKey6 == true)
        {
            grenadeCurrentAmmo = newShooting.grenadeCurrentAmmo;
            AmmoAmount.text = grenadeCurrentAmmo.ToString() + " / " + newShooting.grenadeMaxAmmo.ToString();
        }
    }
}