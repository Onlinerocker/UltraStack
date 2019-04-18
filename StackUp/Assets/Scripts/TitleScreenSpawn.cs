using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenSpawn : MonoBehaviour
{
    public GameObject[] blocks;
    public float timeToSpawn;
    private float timeLeft;


    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, blocks.Length);
        GameObject obj = GameObject.Instantiate(blocks[rand], new Vector3(Random.Range(-5F, 5f), 14f, 10), Quaternion.Euler(0, 0, 0));
        obj.GetComponent<Move>().enabled = false;
        obj.GetComponent<LookForGround>().enabled = false;
        timeLeft = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            int rand = Random.Range(0, blocks.Length);
            GameObject obj = GameObject.Instantiate(blocks[rand], new Vector3(Random.Range(-5F, 5f), 14f, 10), Quaternion.Euler(0, 0, 0));
            obj.GetComponent<Move>().enabled = false;
            obj.GetComponent<LookForGround>().enabled = false;
            timeLeft = timeToSpawn;
        }
    }
}
