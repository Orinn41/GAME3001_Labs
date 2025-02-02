using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Starship : AgentObject
{
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    // Add fields for whisper length, angle and avoidance weight.
    [SerializeField] float whiskerLenght;
    [SerializeField] float whiskerAngle;
    [SerializeField] float avoidanceWeight;
    [SerializeField] LayerMask whiskerLayer;
    [SerializeField] float whiskerAngle2;
    [SerializeField] float whiskerLenght2;
    private Rigidbody2D rb;

    new void Start() // Note the new.
    {
        base.Start(); // Explicitly invoking Start of AgentObject.
        Debug.Log("Starting Starship.");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (TargetPosition != null)
        {
            // Seek();
            SeekForward();
            // Add call to AvoidObstacles.
            AvoidObstacles();
        }
    }

    private void AvoidObstacles()
    {
        // Seek();
        bool hitUp = CastWhisker(whiskerAngle2, Color.cyan);
        bool hitDown = CastWhisker(-whiskerAngle2,Color.white);
       bool hitRight = CastWhisker(whiskerAngle, Color.red);
       bool hitLeft = CastWhisker(-whiskerAngle, Color.blue);
        
        // Adjust rotation based on detected obstacles.
        if(hitLeft || hitUp)
        {
            RotateCounterClockwise();
        }
        else if(hitRight || hitDown)
        {
            RotateClockwise();
        }
       
    }

    private void RotateCounterClockwise()
    {
        // Rotate counterclockwise based on rotationSpeed and a weight.
        transform.Rotate(Vector3.forward, rotationSpeed * avoidanceWeight * Time.deltaTime);
    }

    private void RotateClockwise()
    {
        // Rotate clockwise based on rotationSpeed and a weight.
        transform.Rotate(Vector3.forward, -rotationSpeed * avoidanceWeight * Time.deltaTime);   
            
    }

    // Add CastWhisker method. I removed it entirely.
    private bool CastWhisker(float angle, Color color)
    {
        bool hitResult = false;
        Color rayColor = color;
        // Calculate the direction of the whisker
        Vector2 whiskerDirection = Quaternion.Euler(0,0,angle) * transform.up;

        // Cast a ray in the whisker direction 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, whiskerDirection, whiskerLenght, whiskerLayer);
        // Check if the ray hits an obstacle 
        if (hit.collider != null)
        {
            Debug.Log("Obstacle detected!");
            rayColor = Color.green;
            hitResult = true;
        }
        Debug.DrawRay(transform.position, whiskerDirection * whiskerLenght, rayColor);

        return hitResult;
    }
    //
    //
    //

    private void SeekForward() // A seek with rotation to target but only moving along forward vector.
    {
        // Calculate direction to the target.
        Vector2 directionToTarget = (TargetPosition - transform.position).normalized;

        // Calculate the angle to rotate towards the target.
        float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 90.0f; // Note the +90 when converting from Radians.

        // Smoothly rotate towards the target.
        float angleDifference = Mathf.DeltaAngle(targetAngle, transform.eulerAngles.z);
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationAmount = Mathf.Clamp(angleDifference, -rotationStep, rotationStep);
        transform.Rotate(Vector3.forward, rotationAmount);

        // Move along the forward vector using Rigidbody2D.
        rb.velocity = transform.up * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Target")
        {
            GetComponent<AudioSource>().Play();
            // What is this!?! Didn't you learn how to create a static sound manager last week in 1017?
        }
    }
}
