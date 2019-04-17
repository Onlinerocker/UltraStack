using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 6.0f;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && Input.GetKeyUp(KeyCode.Z))
        {
            this.transform.Rotate(new Vector3(0, 0, 90), Space.World);
        }

        if (canMove && Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        }

        if (canMove && Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        }

        if (canMove && Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed * Time.deltaTime, this.transform.position.z);
        }
    }

    public void setCanMove(bool val)
    {
        canMove = val;
    }
}
