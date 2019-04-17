using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public Text score;
    private float scoreVal;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "0m";
        scoreVal = 0f;
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
}
