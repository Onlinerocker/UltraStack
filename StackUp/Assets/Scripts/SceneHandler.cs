using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class SceneHandler : MonoBehaviour
{
    public Text gameOver;
    public Text highScore;
    public Button replayBtn;
    public ScoreHandler score;
    public GameObject cube;
    public SpawnHandler spawn;
    public string scene;

    private int adInd;

    public void Start()
    {
        adInd = 0;
    }

    public void replayGame()
    {
        //get rid of cubes
        //spawn new one above
        //set score to zero
        if((adInd % 5 == 0 || adInd == 0) && Advertisement.IsReady())
        {
            ShowOptions options = new ShowOptions { resultCallback = handleShowResult };
            Advertisement.Show(options);
        }
        else
        {
            startGame();
        }
        adInd++;
    }

    public void changeScene()
    {
        SceneManager.LoadScene(scene);
    }

    private void startGame()
    {
        gameOver.text = "";
        highScore.text = "";
        highScore.gameObject.GetComponent<Emphasize>().setStart(false);
        replayBtn.transform.parent.position = new Vector3(100000, 0, 0);

        foreach (Move obj in GameObject.FindObjectsOfType<Move>())
        {
            Destroy(obj.gameObject);
        }

        spawn.setCanSpawn(true);
        int rot = Random.Range(0, 4);
        GameObject.Instantiate(cube, new Vector3(Random.Range(-2.5F, 2.5f), 15f, 0), Quaternion.Euler(0, 0, 90 * rot));
        score.setScore(0);
    }

    private void handleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                startGame();
                break;
            case ShowResult.Skipped:
                startGame();
                break;
            case ShowResult.Failed:
                startGame();
                break;
            default:
                startGame();
                break;
        }
    }
}
