using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EmailSpawner : MonoBehaviour
{
    public GameObject emailPrefab;
    public Transform gridTransform;
    private TextMeshProUGUI emailAmount;
    [Space(10)]
    [Header("Non-Spam Emails")]
    public List<EmailBase> NON_SPAM_emails = new List<EmailBase>(); //normal email bases that are NOT SPAM
    [Space(20)]
    [Header("Spam Emails")]
    public List<EmailBase> SPAM_emails = new List<EmailBase>(); //spam email bases to be deleted
    [Space(40)]
    public int spamInCurrentEmails;
    private void Awake()
    {
        emailAmount = GameObject.Find("EmailAmountText").GetComponent<TextMeshProUGUI>();
        //PersistentData.Instance.EmailBacklog = 0;
        int j = Random.Range(5, 10);
        spawnEmailMix(j);
    }

    private void Update()
    {
        ScanEmails();
        emailAmount.text = "Number of Emails: " + gridTransform.childCount;
        if (spamInCurrentEmails == 0)
        {
            PersistentData.Instance.Email = true;
            SceneManager.LoadScene("Desktop");
        }
    }

    public EmailBase randomEmail()
    {
        int i = Random.Range(1, 6);

        if(i > 3)
        {
            return NON_SPAM_emails[Random.Range(0, NON_SPAM_emails.Count - 1)];
        }
        else
        {
            return SPAM_emails[Random.Range(0, SPAM_emails.Count - 1)];
        }
    }

    public void spawnEmailMix(int Amount) //should be called when the needs bar is < 100% && > 50%
    {
        for (int i = 0; i < Amount; i++)
        {
            EmailBase eb = randomEmail();
            GameObject go = Instantiate(emailPrefab, gridTransform.position, Quaternion.identity);
            go.GetComponent<EmailPrefab>().AddEmail(eb.EmailTitle, eb.isSpam);
            go.transform.SetParent(gridTransform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }

            EmailBase ec = SPAM_emails[0];
            GameObject ga = Instantiate(emailPrefab, gridTransform.position, Quaternion.identity);
            ga.GetComponent<EmailPrefab>().AddEmail(ec.EmailTitle, ec.isSpam);
            ga.transform.SetParent(gridTransform);
            ga.transform.localScale = new Vector3(1, 1, 1);
    }

    public void spawnSpamEmails(int Amount)//should be called when the needs bar is < 50%
    {
        for (int i = 0; i < Amount; i++)
        {
            EmailBase eb = SPAM_emails[Random.Range(0, SPAM_emails.Count - 1)];
            GameObject go = Instantiate(emailPrefab, gridTransform.position, Quaternion.identity);
            go.GetComponent<EmailPrefab>().AddEmail(eb.EmailTitle, eb.isSpam);
            go.transform.SetParent(gridTransform);
            go.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void ScanEmails()
    {
        int i = 0;
        foreach(Transform child in gridTransform)
        {
            if(child.GetComponent<EmailPrefab>().isSpam)
            {
                i++;
            }
        }

        spamInCurrentEmails = i;
    }

}

[System.Serializable]
public class EmailBase
{
    [TextArea(2,5)]
    public string EmailTitle;
    public bool isSpam;
}