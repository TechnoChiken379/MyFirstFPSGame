using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{
    public playerMovement health;
    private GameObject HealthGameObject;
    private TMPro.TMP_Text Health;
    public int healthPoints;
    private playerMovement playerMovement;

    void Start()
    {
        healthPoints = playerMovement.healthPointsAmount;
        HealthGameObject = GameObject.Find("Health");
        Health = HealthGameObject.GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {

    }

    private void LateUpdate()
    {
        healthPoints = playerMovement.healthPointsAmount;
        Health.text = healthPoints.ToString() + "HP";
    }
}