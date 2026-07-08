using UnityEngine;

public class move_camra : MonoBehaviour
{
    private float move_speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move_speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.forward * Time.deltaTime * move_speed, Space.World);
    }
}
