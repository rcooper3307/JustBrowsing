using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmailPrefab : MonoBehaviour
{
    public TextMeshProUGUI EmailName;
    public int deductablePoints = 10;
    public bool isSpam;

    public void AddEmail(string emailName, bool isSpam)
    {
        EmailName.text = emailName;
        this.isSpam = isSpam;
    }

    public void deleteEmail()
    {
        if(isSpam)
        {
            Destroy(gameObject);
        }
        else //is not spam aka grandma's emails
        {
            //deduct from points
            Destroy(gameObject);

        }
    }

}
