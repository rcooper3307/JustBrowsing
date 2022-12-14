using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupADSpawner : MonoBehaviour
{
    public int amount;

    public GameObject[] ads;

    public void spawnAds()
    {
        for (int i = 0; i < amount; i++)
        {
            int posX = Random.Range(-3, 3);
            int posY = Random.Range(-2, 2);
            int posz = 10;
            Vector3 pos = new Vector3(posX, posY, posz);
            GameObject go = Instantiate(ads[Random.Range(0, ads.Length)], pos, Quaternion.identity);
            go.transform.SetParent(gameObject.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void spawnSingleAd(int j)
    {
        for (int i = 0; i < j; i++)
        {
            int posX = Random.Range(-3, 3);
            int posY = Random.Range(-2, 2);
            int posz = 10;
            Vector3 pos = new Vector3(posX, posY, posz);
            GameObject go = Instantiate(ads[Random.Range(0, ads.Length)], pos, Quaternion.identity);
            go.transform.SetParent(gameObject.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public bool checkAdsAlive()
    {
        bool b = false;
        foreach(Transform child in gameObject.transform)
        {
            b = true;
        }

        return b;
    }

}
