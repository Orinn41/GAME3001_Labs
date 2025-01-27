using UnityEngine;

public class SeekingBehavior : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position = direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
