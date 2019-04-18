﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float offset;
    private float speed = 6.0f;
    private bool canMove;

    private bool moving;
    private float time;

    private Vector3 sTouch;
    private Vector3 eTouch;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            time += Time.deltaTime;

            if(touch.phase == TouchPhase.Began)
            {
                offset = Camera.main.WorldToScreenPoint(this.transform.position).x - touch.position.x;
                sTouch = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                moving = true;

                if(Vector3.Distance(sTouch, touch.position) > 10)
                {
                    Vector3 screen = Camera.main.WorldToScreenPoint(this.transform.position);
                    Vector3 newPoint = new Vector3(touch.position.x + offset, screen.y, screen.z);
                    Vector3 newWorld = Camera.main.ScreenToWorldPoint(newPoint);

                    this.transform.position = newWorld;
                }
            }

            if(touch.phase == TouchPhase.Ended)
            {
                eTouch = touch.position;
                if(Vector3.Distance(sTouch, eTouch) <= 10)
                {
                    this.transform.Rotate(new Vector3(0, 0, 90), Space.World);
                }
            }

            /*if ((time <= 0.15f || moving == false) && touch.phase == TouchPhase.Ended)
            {
                this.transform.Rotate(new Vector3(0, 0, 90), Space.World);
                moving = false;
                time = 0;
                return;
            }

            if (moving && touch.phase == TouchPhase.Ended)
            {
                moving = false;
                time = 0;
            }*/
        }

        if (canMove && Input.GetKeyDown(KeyCode.Z))
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