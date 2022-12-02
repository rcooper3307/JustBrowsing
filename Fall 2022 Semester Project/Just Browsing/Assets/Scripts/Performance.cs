using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Performance : MonoBehaviour
{
    const int NUM_HIGH_SCORES = 5;
    const string NAME_KEY = "Player";
    const string SCORE_KEY = "Score";
    const string GRADE_KEY = "Grade";

    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] string playerGrade;

    [SerializeField] TextMeshProUGUI[] nameTexts;
    [SerializeField] TextMeshProUGUI[] scoreTexts;
    [SerializeField] TextMeshProUGUI[] gradeTexts;

    void Start()
    {
        //gets the name and score for this current session
        playerName = PersistentData.Instance.GetName();
        playerScore = PersistentData.Instance.GetScore();
        playerGrade = gradeMe(playerScore);

        SaveHighScores();
        //1 Player1
        //1 Score1 
        //2 Player2
        //2 Score2 ...etc
        for (int i = 1; i <= NUM_HIGH_SCORES; i++)
        {
            Debug.Log(i + " " + PlayerPrefs.GetString(NAME_KEY + i) + " ");
            Debug.Log(i + " " + PlayerPrefs.GetInt(SCORE_KEY + i) + " ");
            Debug.Log(i + " " + PlayerPrefs.GetString(GRADE_KEY + i) + " ");
        }

        ShowHighScores();
    }

    public void SaveHighScores()
    {
        //1 Player1
        //1 Score1 
        //2 Player2
        //2 Score2 ...etc
        for (int i = 1; i <= NUM_HIGH_SCORES; i++)
        {
            Debug.Log(i + " " + PlayerPrefs.GetString(NAME_KEY + i) + " ");
            Debug.Log(i + " " + PlayerPrefs.GetInt(SCORE_KEY + i) + " ");
            Debug.Log(i + " " + PlayerPrefs.GetString(GRADE_KEY + i) + " ");
        }
        //while i is less than 5, i goes up
        for (int i = 1; i <= NUM_HIGH_SCORES; i++)
        {

            string currentNameKey = NAME_KEY + i; //Playeri
            string currentScoreKey = SCORE_KEY + i; //Scorei
            string currentGradeKey = GRADE_KEY + i; //Gradei

            if (PlayerPrefs.HasKey(currentScoreKey)) //if the key scorei exists in player prefs
            {
                int currentScore = PlayerPrefs.GetInt(currentScoreKey); //retrieve the score currently stored in scorei
                if (playerScore > currentScore) //if the playerScore is higher than the one stored in scorei
                {
                    int tempScore = currentScore; //store the scorei in a temp variable
                    string tempName = PlayerPrefs.GetString(currentNameKey); //store the playeri string in a temporary variable
                    string tempGrade = PlayerPrefs.GetString(currentGradeKey); //store the gradei string in a temporary variable

                    PlayerPrefs.SetString(currentNameKey, playerName); //set the name for namei to the currentplayer's name
                    PlayerPrefs.SetInt(currentScoreKey, playerScore); //set the score for scorei to the currentplayer's score
                    PlayerPrefs.SetString(currentGradeKey, playerGrade); //set the grade for gradei to the currentplayer's grade

                    playerName = tempName; //the old variable for playerName is set to the old namei player's name
                    playerScore = tempScore; //the old variable for playerScore is set to the old scorei player's score
                    playerGrade = tempGrade; //the old variable for playerGrade is set to the old gradei player's grade
                    //this is so that in the next iteration of the loop it uses the old name and scores as parameters
                }
            }
            else //if playeri does not exist in player prefs
            {
                PlayerPrefs.SetString(currentNameKey, playerName); //set a key in playerprefs for playeri with the value of the current playerName
                PlayerPrefs.SetInt(currentScoreKey, playerScore); //set a key in playerprefs for scorei with the value of playerScore
                PlayerPrefs.SetString(currentGradeKey, playerGrade); //set a key in playerprefs for gradei with the value of playerGrade
                return;
            }
        }
    }

    public void ShowHighScores()
    {
        //this just sets the text in the fields to reflect the scores
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            Debug.Log(i + " ");
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY + (i + 1));
            scoreTexts[i].text = PlayerPrefs.GetInt(SCORE_KEY + (i + 1)).ToString();
            gradeTexts[i].text = PlayerPrefs.GetString(GRADE_KEY + (i + 1));
        }
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


        return s;
    }
}
