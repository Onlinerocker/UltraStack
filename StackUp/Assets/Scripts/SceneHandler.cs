using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public Text gameOver;
    public Button replayBtn;
    public ScoreHandler score;
    public GameObject cube;
    public SpawnHandler spawn;
    public string scene;

    public void replayGame()
    {
        //get rid of cubes
        //spawn new one above
        //set score to zero

        gameOver.text = "";
        replayBtn.transform.parent.position = new Vector3(2000, 0, 0);

        foreach(Move obj in GameObject.FindObjectsOfType<Move>())
        {
            Destroy(obj.gameObject);
        }

        spawn.setCanSpawn(true);
        GameObject.Instantiate(cube, new Vector3(Random.Range(-2.5F, 2.5f), 6.81f, 0), Quaternion.Euler(0, 0, 0));
        score.setScore(0);
    }

    public void changeScene()
    {
        SceneManager.LoadScene(scene);
    }
}
