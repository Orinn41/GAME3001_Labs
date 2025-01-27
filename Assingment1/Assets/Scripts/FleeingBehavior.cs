using UnityEngine;

public class FleeingBehavior : MonoBehaviour
{
    public Transform enemy;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            Vector3 direction = (transform.position - enemy.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
