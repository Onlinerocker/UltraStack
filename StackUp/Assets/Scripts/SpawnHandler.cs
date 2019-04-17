using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    private bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    public void setCanSpawn(bool val)
    {
        canSpawn = val;
    }

    public bool getCanSpawn()
    {
        return canSpawn;
    }
}
