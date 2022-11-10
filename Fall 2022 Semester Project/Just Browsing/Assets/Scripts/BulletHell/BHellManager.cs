using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BHellManager : MonoBehaviour
{
    public int health = 2;
    private GameObject player;
    public GameObject spawner;
    public bool started;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawner.SetActive(false);
    }

    public void TakeDamage()
    {
        health--;

        if (health == 0)
        {
            Destroy(player);
            started = false;
            spawner.SetActive(false);
        }
    }

    public void seenStart()
    {
        spawner.SetActive(true);
        started = true;
    }

}
