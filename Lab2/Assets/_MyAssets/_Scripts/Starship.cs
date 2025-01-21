using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship : AgentObject
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float rotationSpeed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        Debug.Log("Starting Starship....");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TargetPosition != null)
        {
            // Seek();
            SeekForward();
        }
    }

    private void Seek()
    {
        //Calculate direction to target 
        Vector2 direction = (TargetPosition - transform.position).normalized;
        //Calculate desired velocity using kinematic seek equation
        Vector2 desiredVelocity = direction * movementSpeed;
        //Calculate the steering force
        Vector2 steeringForce = desiredVelocity - rb.velocity;
        //Change velocity to desired velocity
        //rb.velocity = desiredVelocity;
        //Apply the steering force to the agent 
        rb.AddForce(steeringForce);
    }

    private void SeekForward() // A seek with rotation to target but only moving aling forward vector 
    {
        //Cccalculate direction to target 
        Vector2 direction = (TargetPosition - transform.position).normalized;
        //Calculate the angle to rotate towards the target
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90.0f;

        //Smmothly rotate towards to target 
        float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        transform.Rotate(Vector3.forward, rotationAmount);

        //Move along the forward vector using rigidbody2D
        rb.velocity = transform.up * movementSpeed;
    }
}
