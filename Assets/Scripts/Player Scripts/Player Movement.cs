using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trackNumber = 0;
        moveSpeed = 0.2f;
        current_track = "middle";
        move_direction = "";
        isSideMoving = false;
        sideSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
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


