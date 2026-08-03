using TMPro;
using UnityEngine;

public class uiscipt : MonoBehaviour
{
    public static int score = 0;
    [SerializeField]
    public GameObject textObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textObj.GetComponent<TMPro.TMP_Text>().text = $"Score: {score}";
    }
}
