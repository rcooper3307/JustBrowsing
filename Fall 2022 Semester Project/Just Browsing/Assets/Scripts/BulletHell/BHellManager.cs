using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
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
            gameOver.Invoke();
        }
    }

    public void resultStatus(string result)
    {
        switch(result)
        {
            case "win":
                //give points n return to desktop
                break;
            case "lost":
                //apply virus effect to computer
                break;
        }
    }

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
        gameWin.Invoke();
    }

    public void Return()
    {
        SceneManager.LoadScene("Desktop");
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
