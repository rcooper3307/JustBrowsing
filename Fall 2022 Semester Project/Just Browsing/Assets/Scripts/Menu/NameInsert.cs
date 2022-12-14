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
    public TextMeshProUGUI v;

    private void Awake()
    {
        this.gameObject.SetActive(false);
        textgo.SetActive(false);
    }

    public void startGame()
    {
        textgo.SetActive(true);
        v.text = "";
        if (inputf.text.Length != 0 && inputf.text.Length <= 12)
        {
            PersistentData.Instance.SetName(inputf.text);
            SceneManager.LoadScene("Desktop");
        }
        else if (inputf.text.Length > 12)
        {
            v.text = "Less than 12 Characters in Name!!";
        }
        else
        {
            v.text = "Name Required!!";
        }
    }
}
