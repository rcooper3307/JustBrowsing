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

    public int tab;

    private void Awake()
    {
        count = 0;
        button.SetActive(true);
    }

    public void viewing()
    {
        switch(count)
        {
            case 0:
                int i = Random.Range(8, 12);
                pop.amount = i;
                pop.spawnAds();
                count++;
                break;
            case 1:
                StartCoroutine(end());
                break;
        }
    }

    IEnumerator end()
    {
        if(tab == 0)
        {
            button.SetActive(false);
            vid.sprite = vidChange;
            PersistentData.Instance.Video = true;
            yield return new WaitForSecondsRealtime(2);
            SceneManager.LoadScene("Desktop");
        }

        if(tab == 1)
        {
            button.SetActive(false);
            vid.sprite = vidChange;
            PersistentData.Instance.Game = true;
            yield return new WaitForSecondsRealtime(2);
            SceneManager.LoadScene("Desktop");
        }
    }

    public void gotcha()
    {
        SceneManager.LoadScene("Mal-WareBulletHell");
    }
}
