
using UnityEngine;

public class player_scripts : MonoBehaviour
{

    [SerializeField]
    float move_speed;
    [SerializeField]
    string move_direction;
    [SerializeField]
    string current_track;
    [SerializeField]
    bool isSideMoving;
    [SerializeField]
    int sideSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move_speed = 5f;
        move_direction = "";
        current_track = "middle";
        isSideMoving = false;
        sideSpeed = 5;


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * move_speed, Space.World);
        if (isSideMoving == true && move_direction == "left")
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed, Space.World);
        }
        if (isSideMoving == true && move_direction == "right")
        {
            transform.Translate(Vector3.right * Time.deltaTime * sideSpeed, Space.World);
        }
    }
    public void onClickLeft()
    {
        if (current_track == "middle")
        {
            move_direction = "left";
            current_track = "left";
            isSideMoving = true;
        }
        if (current_track == "right")
        {
            move_direction = "left";
            current_track = "middle";
            isSideMoving = true;
        }
    }
    public void onClickRight()
    {
        if (current_track == "middle")
        {
            move_direction = "right";
            current_track = "right";
            isSideMoving = true;
        }
        if (current_track == "left")
        {
            move_direction = "right";
            current_track = "middle";
            isSideMoving = true;
        }
    }
}
