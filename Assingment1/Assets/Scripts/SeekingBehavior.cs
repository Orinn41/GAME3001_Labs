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
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + (Vector2)direction, speed * Time.deltaTime);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
         
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
