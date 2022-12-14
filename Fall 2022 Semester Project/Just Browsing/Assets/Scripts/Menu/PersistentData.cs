using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public bool highscoreReset = false;
    public bool firstViewingScene = false;
    public bool[] seenInfo = { false, false, false, false };

    [Space(30)]

    public string previousScene, currentScene, tempScene;
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
        sceneManaging();
        startofGame();

    }

    private void Update()
    {
        if(NS != null)
        {
            refreshSlider();
            startofGame();
        }
        
        sceneManaging();

        if(playerScore < 0)
        {
            playerScore = 0;
        }
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
            PlayerPrefs.SetFloat("PassBar", 60);
            Time.timeScale = 0f;
            
            //firstRound = true;
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

    public void sceneManaging()
    {
        tempScene = SceneManager.GetActiveScene().name;
        if (previousScene == "")
        {
            previousScene = SceneManager.GetActiveScene().name;
        }

        if(currentScene == "")
        {
            currentScene = tempScene;
        }

        if(previousScene == currentScene && currentScene != tempScene || previousScene != currentScene && currentScene != tempScene)
        {
            previousScene = currentScene;
            currentScene = tempScene;
        }
    }

    public void returnPrevScene()
    {
        SceneManager.LoadScene(previousScene);
    }

    public void cleanseData()
    {
        playerName = "";
        playerScore = 0;
        firstRound = false;
    }
    
}

