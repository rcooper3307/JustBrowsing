using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class popupADS : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    public void clickedAd()
    {
        SceneManager.LoadScene("Mal-WareBulletHell");
    }

    public void deleteAd()
    {
        StartCoroutine(close());
    }

    IEnumerator close()
    {
        anim.SetBool("close", true);

        yield return new WaitForSeconds(1);

        Destroy(transform.gameObject);
    }
}
