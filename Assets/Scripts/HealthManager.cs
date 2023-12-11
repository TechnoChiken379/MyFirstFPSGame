using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public playerMovement health;
    private GameObject HealthGameObject;
    private TMPro.TMP_Text Health;
    private int healthPoints;
    public playerMovement playerMovement;

    void Start()
    {
        healthPoints = playerMovement.healthPointsAmount;
        HealthGameObject = GameObject.Find("Health");
        Health = HealthGameObject.GetComponent<TMPro.TMP_Text>();
    }

    private void Update()
    {
        Health.text = healthPoints.ToString() + "HP";
    }

    // Call this method to increase the score
    public void DecreaseHealth(playerMovement playerMovement)
    {
        //PlayerHealth();
    }
}