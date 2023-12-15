using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogBox : MonoBehaviour
{
    [SerializeField] public int lettersPerSecond;
    [SerializeField] TextMeshProUGUI welcomeText;
    [SerializeField] float delayBeforeStart = 0f;
    public playerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDialogAfterDelay());
    }

    void Update()
    {
        LettersPerSecond(playerMovement);
    }

    IEnumerator StartDialogAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        
        string text = welcomeText.text;
        StartCoroutine(TypeDialog(text));
    }

    IEnumerator TypeDialog(string dialog)
    {
        welcomeText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            welcomeText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }
    public void LettersPerSecond(playerMovement playerMovement)
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            lettersPerSecond = 100;
        }
        if (Input.GetKey(KeyCode.RightAlt))
        {
            playerMovement.healthPointsAmount = playerMovement.currentAmountHealthPoints;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
