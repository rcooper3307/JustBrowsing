using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BHellManager : MonoBehaviour
{
    public int health = 2;
    private GameObject player;
    public bool started;
    public bool complete = false;
    public AudioClip audioex;
    public AudioClip audiostruck;
    public AudioClip audiowin;
    private AudioSource audiosource;
    [Space(20)]

    public UnityEvent startGame;
    public UnityEvent gameOver;
    public UnityEvent gameWin;

    public int result = 0;
    private void Update()
    {
        startingCheck();
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audiosource = GetComponent<AudioSource>();
    }

    public void TakeDamage()
    {
        playerHit();
        health--;
        if (health == 0)
        {
            Destroy(player);
            result = 2;
            gameOver.Invoke();
        }
    }

    //public void resultStatus(string result)
    //{
    //    switch(result)
    //    {
    //        case "win":
    //            //give points n return to desktop

    //            break;
    //        case "lost":
    //            //apply virus effect to computer
    //            break;
    //    }
    //}

    public void startingCheck()
    {
        if(!started && Input.GetKeyDown(KeyCode.Space))
        {
            startGame.Invoke();
        }


    }

    public void startedTrue()
    {
        started = true;
    }

    public void scanCompleted()
    {
        result = 1;
        gameWin.Invoke();
    }

    public void Return()
    {
        if(result == 1)
        {
            //int i = PersistentData.Instance.GetScore();
            //int j = i + 250;
            PersistentData.Instance.updateScore(250);

            SceneManager.LoadScene("Desktop");
        }
        else if(result == 2)
        {
            //int i = PersistentData.Instance.GetScore();
            //int j = i - 250;
            PersistentData.Instance.updateScore(-250);
            SceneManager.LoadScene("HighScores");
            //end game
        }
    }

    public void enemyDeath()
    {
        audiosource.PlayOneShot(audioex);
    }

    public void playerHit()
    {
        audiosource.PlayOneShot(audiostruck);
    }

    public void winSound()
    {
        if(!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(audiowin);
        }
    }
}
