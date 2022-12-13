using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VideoViewing : MonoBehaviour
{
    public int count;
    public popupADSpawner pop;
    public GameObject button;
    public Sprite vidChange;
    public Image vid;

    public int adAmount;
    public bool adSpotFree = true;
    public bool started = false;
    private void Awake()
    {
        count = 0;
        button.SetActive(true);
        started = false;
        adSpotFree = true;
    }

    private void Update()
    {
        consecutivePopups();
    }

    public void buttonPressed()
    {
        
        switch (count)
        {
            case 0:
                adAmount = Random.Range(3, 4);
                started = true;
                button.GetComponent<Button>().interactable = false;
                count++;
                break;
            case 1:
                StartCoroutine(end());
                break;
        }

    }

    public void consecutivePopups()
    {
        if (pop.transform.childCount == 0 && !adSpotFree)
        {
            adAmount -= 1;
            adSpotFree = true;
        }

        if (started)
        {
            if (adAmount > 0 && adSpotFree)
            {
                
                pop.spawnSingleAd(Random.Range(2, 3));
                adSpotFree = false;
            }

            if(pop.transform.childCount == 0 && adAmount == 0)
            {
                button.GetComponent<Button>().interactable = true;
            }
        }
    }

    IEnumerator end()
    {
        button.SetActive(false);
        vid.sprite = vidChange;
        PersistentData.Instance.Game = true;
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("Desktop");
    }

    public void gotcha()
    {
        SceneManager.LoadScene("Mal-WareBulletHell");
    }
}
