using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class VideoButtonMash : MonoBehaviour
{
    public Slider m_Slider;
    public Image SliderFill;
    public TextMeshProUGUI percent;
    public TextMeshProUGUI Notice;
    public Color[] colors;
    public bool startMash = false;
    public bool pauseMash = false;
    [Space(20)]
    public GameObject group;
    public popupADSpawner ads;
    public bool[] checks = { false, false};
    private bool spawnem = false;
    public Animator anim;
    private void Awake()
    {
        startMash = false;
        group.SetActive(false);
        m_Slider.maxValue = 100f;
        m_Slider.value = 0f;
        SliderFill.color = colors[0];
        Notice.text = "MASH SPACEBAR! DELETE ADS!";

    }

    private void Update()
    {
        if(startMash)
        {

            adCheckpoint(m_Slider.value);
            if (Input.GetKeyDown("space") && pauseMash == false)
            {
                m_Slider.value += 5f;
            }

            if(m_Slider.value != 100f)
            {
                m_Slider.value -= 0.6f * Time.deltaTime;
            }
            else
            {
                Notice.text = "COMPLETE!!";
                SliderFill.color = colors[2];
                m_Slider.value = m_Slider.maxValue;
                StartCoroutine(end());
            }

            percent.text = Mathf.Abs(m_Slider.value) + "%";

        }



        Debug.Log(m_Slider.value);
    }

    public void activateMash()
    {
        startMash = true;
        anim.SetBool("play", true);
        group.SetActive(true);
    }

    public void adCheckpoint(float f)
    {
        Notice.text = "MASH SPACEBAR! DELETE ADS!";
        bool[] b = { true, true};

        if(m_Slider.value >= 40f && !checks[0])
        {
            if (!spawnem)
            {
                ads.spawnAds();
                spawnem = true;
            }
            b[0] = false;
            Notice.text = "DELETE ADS!! DELETE THEM!!";
            SliderFill.color = colors[1];
        }

        if (m_Slider.value >= 80f && !checks[1])
        {
            if (!spawnem)
            {
                ads.spawnAds();
                spawnem = true;
            }
            b[1] = false;
            SliderFill.color = colors[1];
            Notice.text = "DELETE ADS!! DELETE THEM!!";
        }

        if (ads.checkAdsAlive())
        {
            pauseMash = true;

        }
        else
        {
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == false)
                {
                    checks[i] = true;
                }
            }
            pauseMash = false;
            spawnem = false;
            SliderFill.color = colors[0];
        }


    }

    IEnumerator end()
    {
        anim.SetBool("play", false);

        PersistentData.Instance.Video = true;
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene("Desktop");
    }
}
