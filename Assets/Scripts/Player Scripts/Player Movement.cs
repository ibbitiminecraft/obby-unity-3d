using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    string move_direction;
    [SerializeField]
    string current_track;
    [SerializeField]
    bool isSideMoving;
    [SerializeField]
    int sideSpeed;
    int trackNumber;
    float xPos;

    Vector2 touchStart ;

    float minSwipeDistance = 50f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trackNumber = 0;
        moveSpeed = 5f;
        current_track = "middle";
        move_direction = "";
        isSideMoving = false;
        sideSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        KeyBoardInput();
        ReadSwipe();
        transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        xPos = transform.position.x;
         if (isSideMoving == true && move_direction == "left")
        {
            Debug.Log("Moving Left");
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed, Space.World);
            if (xPos <= trackNumber)
            {
                transform.position = new Vector3(trackNumber,1,transform.position.z);
                isSideMoving = false;
            }
        }
        if (isSideMoving == true && move_direction == "right")
        {
            transform.Translate(Vector3.right * Time.deltaTime * sideSpeed, Space.World);
             if (xPos >= trackNumber)
            {
                transform.position = new Vector3(trackNumber,1,transform.position.z) ;
                isSideMoving = false;
            }
        }
    }


    public void ReadSwipe()
    {
        if (Input.touchCount == 0) return ;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            touchStart = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            Vector2 delta = touch.position - touchStart;
            if (Math.Abs(delta.x) < minSwipeDistance) return;
            if (Math.Abs(delta.x) < Math.Abs(delta.y)) return;

            if(delta.x > 0) 
                onClickRight();
            else
                onClickLeft();
        }

    }
    public void KeyBoardInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            onClickLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            onClickRight();
        }

    }
     public void onClickLeft()
    {
        if (current_track == "middle")
        {
            move_direction = "left";
            current_track = "left";
            isSideMoving = true;
            trackNumber = -1;
        }
        if (current_track == "right")
        {
            move_direction = "left";
            current_track = "middle";
            isSideMoving = true;
            trackNumber = 0;
        }
    }
    public void onClickRight()
    {
        if (current_track == "middle")
        {
            move_direction = "right";
            current_track = "right";
            isSideMoving = true;
            trackNumber = 1;
        }
        if (current_track == "left")
        {
            move_direction = "right";
            current_track = "middle";
            isSideMoving = true;
            trackNumber = 0;
        }
    }
}


