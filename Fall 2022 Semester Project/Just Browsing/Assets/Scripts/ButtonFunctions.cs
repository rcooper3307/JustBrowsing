using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] GameObject[] instructionPopUp;
    [SerializeField] bool clicked = false;

    void Start()
    {
        instructionPopUp = GameObject.FindGameObjectsWithTag("Instructions");

        Debug.Log("Startedd" + SceneManager.GetActiveScene().name);
        Instructions();

        // if(SceneManager.GetActiveScene().name == "Desktop"){
        //   foreach (GameObject g in instructionPopUp)
        //       g.SetActive(false);
        // }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Desktop");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // Makes instruction panel pop up
    public void Instructions(){

      Debug.Log("Into Intructions" + SceneManager.GetActiveScene().name);
      if(clicked){
        Time.timeScale = 0.0f;
        foreach(GameObject g in instructionPopUp)
            g.SetActive(true);
      }
      else{
        Time.timeScale = 1.0f;
        foreach (GameObject g in instructionPopUp)
            g.SetActive(false);
      }

      if(clicked == false){
        clicked = true;
      }
      else{
        clicked = false;
      }
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
