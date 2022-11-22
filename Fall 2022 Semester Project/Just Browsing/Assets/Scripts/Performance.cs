using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Performance : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI points;
    public TextMeshProUGUI Grade;

    private void Awake()
    {
        name.text = "Name: " + PersistentData.Instance.GetName();
        points.text = "Points Racked: " + PersistentData.Instance.GetScore();
        Grade.text = gradeMe(PersistentData.Instance.GetScore());
    }

    public string gradeMe(int i)
    {
        string s = "";
        if(i <= 0)
        {
            s = "F";
        }
        else if(i <= 300 && i > 0)
        {
            s = "D";
        }
        else if (i <= 500 && i > 300)
        {
            s = "C";
        }
        else if (i <= 800 && i > 500)
        {
            s = "B";
        }
        else if (i <= 1000 && i > 800)
        {
            s = "A";
        }
        else if (i >= 1600)
        {
            s = "S";
        }


        return "Grade: " + s;
    }
}
