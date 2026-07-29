using UnityEngine;
using System.Collections;

public class coinscript : MonoBehaviour
{
    private bool isCollected = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 2, 0, Space.World);
        if (isCollected)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 6, Space.World);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        isCollected = true;
        this.gameObject.GetComponent<Animator>().Play("coin animation");
        Debug.Log(":");
        StartCoroutine(DestoryCoin());
    }
    IEnumerator DestoryCoin()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

    }


}