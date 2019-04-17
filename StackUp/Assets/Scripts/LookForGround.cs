using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookForGround : MonoBehaviour
{
    public GameObject[] blocks;
    public bool first;

    private Camera cam;
    private ScoreHandler score;
    private Text loseTxt;
    private GameObject replayBtn;
    private SpawnHandler spawn;

    private bool done;
    private bool latest;
    private bool lose;
    private bool moved;
    private Vector3 newPos;
    private Vector3 losePos;

    private void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
        score = GameObject.FindObjectOfType<ScoreHandler>();
        loseTxt = GameObject.FindGameObjectWithTag("txtLose").GetComponent<Text>();
        replayBtn = GameObject.FindGameObjectWithTag("btnLose");
        spawn = GameObject.FindObjectOfType<SpawnHandler>();

        losePos = new Vector3(0, 1, -13.12f);

        done = false;
        moved = false;
        latest = true;
        lose = false;
    }

    private void Update()
    {
        if (lose)
        {
            loseTxt.text = "Game Over";
            replayBtn.gameObject.transform.localPosition = new Vector3(0, -392, 0);

            if (!moved)
            {
                cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, losePos, 6.0f * Time.deltaTime);
                if (cam.gameObject.transform.position == losePos)
                {
                    moved = true;
                }
            }
            return;
        }

        if (spawn.getCanSpawn() && !lose && !moved && done)
        {
            cam.gameObject.transform.position = Vector3.MoveTowards(cam.gameObject.transform.position, newPos, 3.0f * Time.deltaTime);
            if(cam.gameObject.transform.position == newPos)
            {
                moved = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!first && collision.gameObject.tag == "ground")
        {
            lose = true;
            done = true;
            moved = false;
            spawn.setCanSpawn(false);
            return;
        }

        if (spawn.getCanSpawn() && !done)
        {
            this.GetComponent<Move>().setCanMove(false);

            int rand = Random.Range(0, blocks.Length);
            GameObject.Instantiate(blocks[rand], new Vector3(Random.Range(-2.5f, 2.5f), cam.gameObject.transform.position.y + 10, 0), Quaternion.Euler(0,0,0));
            done = true;
            newPos = new Vector3(cam.gameObject.transform.position.x, this.transform.position.y + 1, cam.gameObject.transform.position.z);
            score.increaseScore(Mathf.Ceil(this.transform.position.y - score.getScore()));
            latest = false;
            //cam.gameObject.transform.Translate(new Vector3(0, 10.0f, 0) * Time.deltaTime, Space.World);
        }


            
        //spawn new guy
    }
}
