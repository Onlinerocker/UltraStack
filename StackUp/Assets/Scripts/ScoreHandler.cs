using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public Text score;
    private float scoreVal;
    private float highScore;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "0";
        scoreVal = 0f;

        PlayerPrefs.SetFloat("score", 0);

        if (PlayerPrefs.HasKey("score"))
        {
            highScore = PlayerPrefs.GetFloat("score");
        }
        else
        {
            highScore = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore(float amt)
    {
        if (scoreVal + amt < scoreVal)
            return;

        scoreVal += amt;
        score.text = scoreVal + "";
    }

    public float getScore()
    {
        return scoreVal;
    }

    public void setScore(float val)
    {
        scoreVal = val;
        score.text = scoreVal + "";
    }

    public float getHighScore()
    {
        return highScore;
    }

    public void setHighScore(float val)
    {
        PlayerPrefs.SetFloat("score", val);
        highScore = val;
        PlayerPrefs.Save();
    }
}
