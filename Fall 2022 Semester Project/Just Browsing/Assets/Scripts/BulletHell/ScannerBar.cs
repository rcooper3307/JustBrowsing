using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScannerBar : MonoBehaviour
{
    public Slider slider;
    public int goal;
    public float fillSpeed = 0.85f;
    public bool runStart;
    public TextMeshProUGUI percent;
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
        if (BHC.started)
        {
            slider.maxValue = progressGoal;

            if (slider.value < progressGoal)
            {
                slider.value += fillSpeed * Time.deltaTime;
            }
            else
            {
                slider.value = goal;
            }
        }
        else
        {
            slider.value = 0;
        }

    }
}
