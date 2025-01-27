using UnityEngine;

public class ResetScale : MonoBehaviour
{
    private Vector3 defaultScale = new Vector3(2f, 2f, 2f);

    private void Awake()
    {
        transform.localScale = defaultScale;
    }
    private void OnEnable()
    {
        transform.localScale = defaultScale;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
