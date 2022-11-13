using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScannerBar : MonoBehaviour
{
    public Slider slider;
    public int goal;
    public float fillSpeed;
    public TextMeshProUGUI percent;
    public bool hasFailed = false;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        IntProgress(goal);

        percent.text = Mathf.Round(slider.value) + "%";
    }

    public void IntProgress(float progressGoal)
    {
        BHellManager BHC = GameObject.FindGameObjectWithTag("BHController").GetComponent<BHellManager>();
        if (BHC.started && !hasFailed)
        {
            slider.maxValue = progressGoal;

            if (slider.value < progressGoal)
            {
                slider.value += fillSpeed * Time.deltaTime;
            }
            else
            {
                slider.value = goal;
                BHC.scanCompleted();
            }
        }
        else if(hasFailed)
        {
            slider.value = slider.value;
        }
        else
        {
            slider.value = 0;
        }

    }

    public void failed()
    {
        hasFailed = true;
    }
}
