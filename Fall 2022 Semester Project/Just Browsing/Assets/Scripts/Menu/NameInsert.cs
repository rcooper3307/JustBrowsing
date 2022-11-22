using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NameInsert : MonoBehaviour
{
    public TMPro.TMP_InputField inputf;
    public GameObject textgo;

    private void Awake()
    {
        this.gameObject.SetActive(false);
        textgo.SetActive(false);
    }

    public void startGame()
    {
        if(inputf.text.Length != 0)
        {
            PersistentData.Instance.SetName(inputf.text);
            SceneManager.LoadScene("Desktop");
        }
        else
            textgo.SetActive(true);
    }
}
