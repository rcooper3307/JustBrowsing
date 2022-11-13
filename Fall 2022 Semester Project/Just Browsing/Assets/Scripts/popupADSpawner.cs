using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popupADSpawner : MonoBehaviour
{
    [Range(1f, 12f)]
    public int amount;

    public GameObject[] ads;

    public void spawnAds()
    {
        for (int i = 0; i < amount; i++)
        {
            int posX = Random.Range(-4, 4);
            int posY = Random.Range(-2, 2);

            Vector2 pos = new Vector2(posX, posY);
            GameObject go = Instantiate(ads[Random.Range(0, ads.Length)], pos, Quaternion.identity);
            go.transform.SetParent(gameObject.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
