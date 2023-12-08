using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshPro text;
    public playerMovement health;

    void Start()
    {
        // Initialize the score and update the UI
        UpdateHealthUI();
    }

    // Call this method to increase the score
    public void DecreaseHealth(playerMovement playerMovement)
    {
        //PlayerHealth();
        UpdateHealthUI();
    }

    // Update the UI with the current score
    void UpdateHealthUI()
    {
        if (text != null)
        {
            text.text = "HP: " + health;
        }
    }
}