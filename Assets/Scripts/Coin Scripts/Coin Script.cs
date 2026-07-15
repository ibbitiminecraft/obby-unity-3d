using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0,2,0 , Space.World);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        this.gameObject.GetComponent<Animator>().Play("Coin Shrink");
    }

}

