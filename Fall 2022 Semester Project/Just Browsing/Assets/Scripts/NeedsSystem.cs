using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedsSystem : MonoBehaviour
{
    public int goal;
    public int rewardPoints;
    public bool activate;
    public Gradient gradient;
    [Space(20)]
    public float VideoSpeed;
    public Slider VideoBar;
    [Space(10)]
    public float GameSpeed;
    public Slider GameBar;
    [Space(10)]
    public float EmailSpeed;
    public Slider EmailBar;
    [Space(10)]
    public float PasswordSpeed;
    public Slider PasswordBar;
    public GameObject passwordReseter;
    public GameObject passwordNotice;
    public bool noticePassword;
    private void Awake()
    {
        noticePass(false);
        activateBarStatus(true);
        setBarGoal(goal);
    }

    private void FixedUpdate()
    {
        ProgressNeedsBar(VideoBar, VideoSpeed);
        ProgressNeedsBar(GameBar, GameSpeed);
        ProgressNeedsBar(EmailBar, EmailSpeed);
        ProgressNeedsBar(PasswordBar, PasswordSpeed);

        if (PasswordBar.value == 0 && noticePassword == false)
        {
            noticePass(true);
        }
        
        if(PasswordBar.value != 0)
            noticePass(false);

    }

    public void ProgressNeedsBar(Slider s, float speed)
    {
        if (activate)
        {
            if (s.value > 0)
            {
                s.value -= speed * Time.deltaTime;
                s.fillRect.gameObject.GetComponent<Image>().color = gradient.Evaluate(s.normalizedValue);
            }
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

    public int RefreshNeedsBar(Slider s)
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
        return (int)Mathf.Round(reward);
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
        GameBar.value = goal / 4;
        EmailBar.maxValue = goal;
        EmailBar.value = goal;
        PasswordBar.maxValue = goal;
        PasswordBar.value = 1;//goal / 2;
    }

    public void spawnPasswordReseter()
    {
        GameObject go = Instantiate(passwordReseter, passwordNotice.transform.position, Quaternion.identity);
        go.transform.SetParent(passwordNotice.transform);
        go.transform.localScale = new Vector3(1, 1, 1);
    }
}
