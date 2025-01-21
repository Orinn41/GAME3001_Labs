using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship : AgentObject
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float rotationSPeed;

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
            Seek();
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
}
