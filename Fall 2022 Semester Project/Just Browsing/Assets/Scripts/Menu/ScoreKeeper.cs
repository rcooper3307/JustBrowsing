using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int score;

    private void Start()
    {
        //score = PersistentData.Instance.GetScore();
    }

    public void UpdateScore(int i)
    {
        score += i;
        PersistentData.Instance.SetScore(score);
    }
}
