using System.Collections;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] TextMeshProUGUI welcomeText;
    [SerializeField] float delayBeforeStart = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDialogAfterDelay());
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
}
