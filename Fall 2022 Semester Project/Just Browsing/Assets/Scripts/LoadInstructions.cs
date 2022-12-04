using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadInstructions : MonoBehaviour
{

    void toInstructions()
    {
      SceneManager.LoadScene("GrandIntro");
    }
}
