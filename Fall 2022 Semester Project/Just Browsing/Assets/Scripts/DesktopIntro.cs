using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopIntro : MonoBehaviour
{
    public bool gameReady;

    public GameObject firstNotice;
    public List<GameObject> list = new List<GameObject>();
    public GameObject cover;

    private void Awake()
    {
        gameReady = PersistentData.Instance.firstRound;

        if(!gameReady)
        {
            firstNotice.SetActive(true);

        }
        else
        {
            cover.SetActive(false);
        }
    }
    private void Update()
    {
        getGameReady();
    }
    public void getGameReady()
    {
        if(gameReady)
        {
            foreach(GameObject obj in list)
            {
                obj.SetActive(false);
            }

        }
    }

    public void gameisReady()
    {
        PersistentData.Instance.firstRound = true;
        Time.timeScale = 1f;
    }
}
