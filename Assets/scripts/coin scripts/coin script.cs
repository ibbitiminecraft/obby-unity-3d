using UnityEngine;

public class coinscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 2, 0, Space.World);
    }
    //     void OnTriggerEnter(Collider other)
    //     {
    //         this.gameObject.GetComponent<Animator>().Play("coin shrink animations");
    //     }
    private void OnTriggerEnter(Collider other)
    {
    Animator animator = GetComponent<Animator>();

    if (animator != null)
    {
        animator.Play("coin shrink animations");
    }
    }
}
