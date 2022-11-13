using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class popupADS : MonoBehaviour
{
    public void clickedAd()
    {
        SceneManager.LoadScene("Mal-WareBulletHell");
    }

    public void deleteAd()
    {
        Destroy(transform.gameObject);
    }
}
