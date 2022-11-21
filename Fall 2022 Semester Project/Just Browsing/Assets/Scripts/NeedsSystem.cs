using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NeedsSystem : MonoBehaviour
{
    public ScoreKeeper scoreKeeper;
    public int goal;
    public int rewardPoints;
    public bool activate;
    public Gradient gradient;
    [Space(20)]
    public float VideoSpeed;
    public Slider VideoBar;
    public int VpointsDeduct;
    [Space(10)]
    public float GameSpeed;
    public Slider GameBar;
    public int GpointsDeduct;
    [Space(10)]
    public float EmailSpeed;
    public Slider EmailBar;
    public int EpointsDeduct;
    [Space(10)]
    public float PasswordSpeed;
    public Slider PasswordBar;
    public int PpointsDeduct;
    public GameObject passwordReseter;
    public GameObject passwordNotice;

    public bool noticePassword;
    private bool[] runningQ = { false, false, false, false };
    private void Awake()
    {
        noticePass(false);
        activateBarStatus(true);
        setBarGoal(goal);
    }

    private void FixedUpdate()
    {
        ProgressNeedsBar(VideoBar, VideoSpeed, VpointsDeduct, 0);
        ProgressNeedsBar(GameBar, GameSpeed, GpointsDeduct, 1);
        ProgressNeedsBar(EmailBar, EmailSpeed, EpointsDeduct, 2);
        ProgressNeedsBar(PasswordBar, PasswordSpeed, PpointsDeduct, 3);

        if (PasswordBar.value == 0 && noticePassword == false)
        {
            noticePass(true);
        }
        
        if(PasswordBar.value != 0)
            noticePass(false);

    }

    public void ProgressNeedsBar(Slider s, float speed, int deduct, int boolPOS)
    {
        if (activate)
        {
            if (s.value > 0)
            {
                s.value -= speed * Time.deltaTime;
                s.fillRect.gameObject.GetComponent<Image>().color = gradient.Evaluate(s.normalizedValue);
            }

            if(s.value == 0)
            {
                if (!runningQ[boolPOS])
                {
                    int i = PersistentData.Instance.GetScore();
                    i -= deduct;
                    PersistentData.Instance.SetScore(i);


                    runningQ[boolPOS] = true;
                    StartCoroutine(waitpoints(boolPOS));
                }
            }    
        }
        else
        {
            s.value = s.value;
        }


    }

    public void noticePass(bool b)
    {
        if(b)
        {

            passwordNotice.SetActive(true);
            noticePassword = true;
        }
        else
        {
            passwordNotice.SetActive(false);
            noticePassword = false;
        }
        
    }

    public void RefreshNeedsBar(Slider s)
    {
        int reward;
        int i = (int)Mathf.Round(s.value);
        if (i >= 65 && i < 80) //high points, close bar full, makes player check often
        {
            reward = rewardPoints * (i / 100);
        }
        else if(i >= 30 && i < 65)//mid points
        {
            reward = rewardPoints * (i / 100);
        }
        else if(i >= 10 && i < 30)
        {
            reward = rewardPoints * (i / 100);
        }
        else
        {
            reward = rewardPoints * (i / 100);
        }

        s.value = s.maxValue;
        Debug.Log(reward);

        int j = PersistentData.Instance.GetScore();
        j += reward;


        PersistentData.Instance.SetScore(j);
    }

    public void activateBarStatus(bool b)
    {
        activate = b;
    }

    public void setBarGoal(int goal)
    {
        VideoBar.maxValue = goal;
        VideoBar.value = goal;
        GameBar.maxValue = goal;
        GameBar.value = goal; // 4;
        EmailBar.maxValue = goal;
        EmailBar.value = goal;
        PasswordBar.maxValue = goal;
        PasswordBar.value = goal / 6;
    }

    public void spawnPasswordReseter()
    {
        GameObject go = Instantiate(passwordReseter, passwordNotice.transform.position, Quaternion.identity);
        go.transform.SetParent(passwordNotice.transform);
        go.transform.localScale = new Vector3(1, 1, 1);
    }

    //IEnumerator deductPoints(int value, int deduct, int boolPOS)
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSecondsRealtime(3);
    //        scoreKeeper.score -= deduct;
    //        int i = PersistentData.Instance.GetScore();
    //        i -= deduct;
    //        yield break;
    //        PersistentData.Instance.SetScore(i);
    //    }
    //}

    IEnumerator waitpoints(int boolPOS)
    {
        yield return new WaitForSecondsRealtime(5);
        runningQ[boolPOS] = false;
    }

}
