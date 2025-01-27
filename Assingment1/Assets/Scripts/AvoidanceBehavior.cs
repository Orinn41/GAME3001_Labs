using UnityEngine;

public class AvoidanceBehavior : MonoBehaviour
{
    public Transform target;
    public Transform enemy;
    public float speed = 5f;
    public float avoidDistance = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null &&  enemy != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            if (Vector3.Distance(transform.position, enemy.position) < avoidDistance)
            {
                direction = (transform.position - enemy.position).normalized;
            }
            transform.position += direction * speed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
