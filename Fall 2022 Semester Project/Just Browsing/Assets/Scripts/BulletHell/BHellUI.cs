using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BHellUI : MonoBehaviour
{
    public int hp;
    public TextMeshProUGUI hpText;
    public GameObject resultsGO;
    public TextMeshProUGUI resultsText;
    public GameObject introText;

    private void Awake()
    {
        resultsText.text = "";
        resultsGO.SetActive(false);
    }
    private void Update()
    {
        trackHealth();
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

            hp = playerHP;
            hpText.text = "HEALTH: " + hp.ToString();

        }

        if(hp == 0)
        {
            hpText.text = "Dead End";
        }
    }

    public void scanResult(int scanWin)
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
