using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    bool isCollected = false;
    void Update()
    {
        transform.Rotate(0,2,0 , Space.World);
        if (isCollected)
        {
            transform.Translate(Vector3.up*Time.deltaTime*6,Space.World);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        isCollected = true;
        this.gameObject.GetComponent<Animator>().Play("Coin Shrink");
    }

}

