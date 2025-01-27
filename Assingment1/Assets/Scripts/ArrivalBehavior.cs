using UnityEngine;

public class ArrivalBehavior : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float arrivalDisctance = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float distnace = Vector3.Distance(transform.position, target.position);
            float currentSpeed = speed;
            if (distnace < arrivalDisctance)
            {
                currentSpeed = Mathf.Lerp(0, speed, distnace /  arrivalDisctance);
            }
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + direction, currentSpeed * Time.deltaTime);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        }
    }
}
