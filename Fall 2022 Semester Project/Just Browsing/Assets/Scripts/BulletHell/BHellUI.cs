using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BHellUI : MonoBehaviour
{
    public GameObject hpbar;
    public int hp;
    public Transform healthContainer;
    public GameObject resultsGO;
    public TextMeshProUGUI resultsText;
    public GameObject introText;
    private int scanWin;
    private void Update()
    {
        trackHealth();
        scanResult();

    }

    public void trackHealth()
    {
        BHellManager BHC = GameObject.FindGameObjectWithTag("BHController").GetComponent<BHellManager>();
        int playerHP = BHC.health;

        if(BHC.started)
        {
            introText.SetActive(false);
        }
        

        if (playerHP != hp)
        {
            foreach(Transform child in healthContainer)
            {
                Destroy(child.gameObject);
            }

            hp = playerHP;

            for (int i = 0; i < hp; i++)
            {
                Instantiate(hpbar, healthContainer);
            }
        }

        if(hp == 0)
        {

            gameOver();
        }
    }

    public void gameOver()
    {
        foreach (Transform child in healthContainer)
        {
            Destroy(child.gameObject);
        }

        scanWin = -1;
    }

    public void scanResult()
    {
        switch(scanWin)
        {
            case 0:
                resultsText.text = "";
                resultsGO.SetActive(false);
                break;
            case 1:
                resultsText.text = "VIRUS SCAN SUCCESS";
                resultsGO.SetActive(true);
                break;
            case -1:
                resultsText.text = "VIRUS SCAN FAILED";
                resultsGO.SetActive(true);
                break;
        }
    }
}
