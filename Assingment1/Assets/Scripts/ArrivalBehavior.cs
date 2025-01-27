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
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * currentSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
