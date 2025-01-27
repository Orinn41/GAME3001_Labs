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
            Vector2 direction = (target.position - transform.position).normalized;
            if (Vector2.Distance(transform.position, enemy.position) < avoidDistance)
            {
                direction = (transform.position - enemy.position).normalized;
            }
            transform.position = Vector2.MoveTowards(transform.position, transform.position + (Vector3)direction, speed * Time.deltaTime);
            float angle = Mathf.Atan2(direction.y, direction.x);
            transform.rotation = Quaternion.Euler(new Vector3(0,0,angle)); 
        }
    }
}
