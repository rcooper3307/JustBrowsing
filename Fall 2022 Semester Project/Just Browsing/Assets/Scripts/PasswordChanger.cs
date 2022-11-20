using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordChanger : MonoBehaviour
{
    public List<Button> buttons = new List<Button>();
    public GameObject baseGO;
    [Space(20)]
    private string[] specialCharacters = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", "[", "]", "{", "}" };
    public TextMeshProUGUI wordlimit;
    public TextMeshProUGUI specialchartxt;
    public TextMeshProUGUI keywordtxt;
    public TextMeshProUGUI numbers;
    public TMPro.TMP_InputField inputf;
    [Space(20)]
    private NeedsSystem ns;
    public string keyword;
    public int buttonactive;
    public int correctREQ = 0;
    private bool[] correctOnes = new bool[] { false, false, false, false };
    private void Awake()
    {
        ns = GameObject.Find("BarBase").GetComponent<NeedsSystem>();
        baseGO.SetActive(false);
        buttonScramble();
    }

    private void Update()
    {
        textcolorsGREEN();
    }

    public void buttonScramble()
    {
        buttonactive = Random.Range(0, buttons.Count - 1);


        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        buttons[buttonactive].gameObject.SetActive(true);
        GameObject go = buttons[buttonactive].GetComponent<ButtonHighlight>().text;
        keyword = go.GetComponent<TextMeshProUGUI>().text;

    }

    public void textcolorsGREEN()
    {
        if(inputf.text.Length > 8 && inputf.text.Length < 14)
        {
            wordlimit.color = Color.green;
            correctOnes[0] = true;
        }
        else
        {
            wordlimit.color = Color.red;
            correctOnes[0] = false;
        }

        if(inputf.text.Contains(keyword))
        {
            keywordtxt.color = Color.green;
            correctOnes[1] = true;
        }
        else
        {
            keywordtxt.color = Color.red;
            correctOnes[1] = false;
        }

        if (checknum(inputf.text))
        {
            numbers.color = Color.green;
            correctOnes[2] = true;
        }
        else
        {
            numbers.color = Color.red;
            correctOnes[2] = false;
        }

        if (hasSpec(inputf.text, specialCharacters))
        {
            specialchartxt.color = Color.green;
            correctOnes[3] = true;
        }
        else
        {
            specialchartxt.color = Color.red;
            correctOnes[3] = false;
        }
            

    }

    public void confirmEnter()
    {
        bool totalTrue = false;
        foreach (bool b in correctOnes)
        {
            if(b)
            {
                totalTrue = true;
            }
            else
            {
                totalTrue = false;
            }
        }

        if(totalTrue)
        {
            //give points
            ns.noticePassword = true;
            ns.RefreshNeedsBar(ns.PasswordBar);
            Destroy(gameObject);
        }
    }
    private bool checknum(string s)
    {
        for (int i = 0; i < 9; i++)
        {
            if (s.Contains(System.Convert.ToString(i)))
                return true;
                
        }
        return false;
    }

    public bool hasSpec(string s, string[] arr)
    {
        for (int i = 0; i < specialCharacters.Length; i++)
        {
            if (s.Contains(arr[i]))
                return true;
        }
        return false;
    }
}
