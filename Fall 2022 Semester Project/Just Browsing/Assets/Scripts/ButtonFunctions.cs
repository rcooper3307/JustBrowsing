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

    public void InstructEmail()
    {
        SceneManager.LoadScene("InstructEmail");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Email()
    {
        SceneManager.LoadScene("Email");
    }

    public void Video()
    {
        SceneManager.LoadScene("Browser");
    }

    public void Game()
    {
        SceneManager.LoadScene("GameB");
    }

    public void MalWareBulletHell()
    {
        SceneManager.LoadScene("Mal-WareBulletHell");
    }
}
