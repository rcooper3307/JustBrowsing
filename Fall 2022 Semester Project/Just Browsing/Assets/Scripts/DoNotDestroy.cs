using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoNotDestroy : MonoBehaviour
{
    public static DoNotDestroy instance;

    CanvasGroup canvasGroup;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        //if this object doesn't exist already, set instance to this object. if it already exists in the scene, destroy the extra copy.
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        canvasGroup = GetComponent<CanvasGroup>();

    }
   void Update()
    {
        //when on the computer scenes, the taskbar is visible and interactable
        if ((SceneManager.GetActiveScene().name == "Desktop") || (SceneManager.GetActiveScene().name == "Email")) {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;

        }
        //when on any other scene, the taskbar is invisible and uninteractable
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
        }
    }
}
