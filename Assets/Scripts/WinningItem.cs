using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningItem : MonoBehaviour
{
    void OnCollisionEnter(Collision collisioninfo)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
