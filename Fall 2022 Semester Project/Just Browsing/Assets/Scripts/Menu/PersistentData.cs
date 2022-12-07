using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{
    public int playerScore;
    public string playerName;

    public NeedsSystem NS;
    public bool Video = false;
    public bool Game = false;
    public bool Email = false;
    public bool Pass = false;
    public static PersistentData Instance;

    public bool firstRound = false;
    public bool firstViewingScene = false;
    public bool[] seenInfo = { false, false, false, false };
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        if(NS != null)
        {
            refreshSlider();

        }
        //else
        //{
        //    NS = GameObject.FindGameObjectWithTag("NeedsSystem").GetComponent<NeedsSystem>();
        //}
        startofGame();

    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
        playerName = "";

    }
    public void startofGame()
    {
        if(!firstRound)
        {
            PlayerPrefs.SetFloat("VideoBar", 100);
            PlayerPrefs.SetFloat("GameBar", 100);
            PlayerPrefs.SetFloat("EmailBar", 100);
            PlayerPrefs.SetFloat("PassBar", 10);
            firstRound = true;
        }

    }

    public bool hasSeenInfo(int i)
    {
        return seenInfo[i];
    }
    public void SetName(string s)
    {
        playerName = s;
    }

    public void updateScore(int s)
    {
        playerScore += s;
    }
    public void SetScore(int s)
    {
        playerScore = s;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public void refreshSlider()
    {
        if (Video == true)
        {
            NS.RefreshNeedsBar(NS.VideoBar);
            Video = false;
        }


        if (Game == true)
        {
            NS.RefreshNeedsBar(NS.GameBar);
            Game = false;
        }

        if (Email == true)
        {
            NS.RefreshNeedsBar(NS.EmailBar);
            Email = false;
        }

        if (Pass == true)
        {
            NS.RefreshNeedsBar(NS.PasswordBar);
            Pass = false;
        }
    }

}

