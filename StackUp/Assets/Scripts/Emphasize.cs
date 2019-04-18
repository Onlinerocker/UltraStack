using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emphasize : MonoBehaviour
{
    public float minScale;
    public float maxScale;
    public float speed;

    private bool start;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x + (speed * Time.deltaTime), this.transform.localScale.y + (speed * Time.deltaTime), this.transform.localScale.z);
            if(this.transform.localScale.x > maxScale)
            {
                speed *= -1;
                this.transform.localScale = new Vector3(maxScale, maxScale, this.transform.localScale.z);
            }

            if(this.transform.localScale.x <= minScale)
            {
                speed *= -1;
                this.transform.localScale = new Vector3(minScale, minScale, this.transform.localScale.z);
            }

        }
    }

    public void setStart(bool val)
    {
        start = val;
    }
}
