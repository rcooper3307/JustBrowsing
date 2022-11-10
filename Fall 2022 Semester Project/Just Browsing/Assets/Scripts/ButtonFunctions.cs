using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Desktop");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
