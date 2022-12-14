using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clock;
    //sets the hour to 6pm
    public float timer;


    void DisplayTime()
    {
        int hour = Mathf.FloorToInt(timer / 3600.0f) % 24;
        int minutes = Mathf.FloorToInt(timer / 60.0f) % 60;
        clock.text = string.Format("{0:00}:{1:00}", hour, minutes);
    }

    // Update is called once per frame
    void Update()
    {
        if(!PersistentData.Instance.firstRound)
        {
            timer = 21600.0f;
        }

        //changes the speed of the timer
        timer += Time.deltaTime * 35;
        DisplayTime();

        int hour = Mathf.FloorToInt(timer / 3600.0f) % 24;
        if(hour == 8)
        {
            endGame();
        }
    }

    public void endGame()
    {
        timer = 21600.0f;
        SceneManager.LoadScene("HighScores");
    }
}
