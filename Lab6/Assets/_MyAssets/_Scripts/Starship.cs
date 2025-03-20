using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starship : AgentObject
{
    // TODO: Commented out for Lab 6a.
    // [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float whiskerLength;
    [SerializeField] float whiskerAngle;
    // TODO: Commented out for Lab 6a.
    // [SerializeField] float avoidanceWeight;
    private Rigidbody2D rb;
    // TODO: Add NavigationObject reference for Lab 6a.
    NavigationObject no;
    new void Start() // Note the new.
    {
        base.Start(); // Explicitly invoking Start of AgentObject.
        Debug.Log("Starting Starship.");
        rb = GetComponent<Rigidbody2D>();
        // TODO: Populate NavigationObject reference for Lab 6a.
        no = GetComponent<NavigationObject>();  
    }

    void Update()
    {
        // TODO: Add new whisker and rotation behaviour for Lab 6a.
        bool hit = CastWhisker(whiskerAngle, Color.red);
        transform.Rotate(0f, 0f, Input.GetAxis("Horizontal") + rotationSpeed * Time.deltaTime);
        // 

        // TODO: Commented out for Lab 6a.
        //if (TargetPosition != null)
        //{
        //    // Seek();
        //    SeekForward();
        //    AvoidObstacles();
        //}
    }

    // TODO: Commented out for Lab 6a.
    //private void AvoidObstacles()
    //{
    //    // Cast whiskers to detect obstacles
    //    bool hitLeft = CastWhisker(whiskerAngle, Color.red);
    //    bool hitRight = CastWhisker(-whiskerAngle, Color.blue);

    //    // Adjust rotation based on detected obstacles
    //    if (hitLeft)
    //    {
    //        // Rotate counterclockwise if the left whisker hit
    //        RotateClockwise();
    //    }
    //    else if (hitRight && !hitLeft)
    //    {
    //        // Rotate clockwise if the right whisker hit
    //        RotateCounterClockwise();
    //    }
    //}

    // TODO: Commented out for Lab 6a.
    //private void RotateCounterClockwise()
    //{
    //    // Rotate counterclockwise based on rotationSpeed and a weight.
    //    transform.Rotate(Vector3.forward, rotationSpeed * avoidanceWeight * Time.deltaTime);
    //}

    // TODO: Commented out for Lab 6a.
    //private void RotateClockwise()
    //{
    //    // Rotate clockwise based on rotationSpeed.
    //    transform.Rotate(Vector3.forward, -rotationSpeed * avoidanceWeight * Time.deltaTime);
    //}

    private bool CastWhisker(float angle, Color color)
    {
        bool hitResult = false;
        Color rayColor = color;

        // Calculate the direction of the whisker.
        Vector2 whiskerDirection = Quaternion.Euler(0, 0, angle) * transform.right;

        // TODO: Add for Lab 6a.
        if (no.HasLOS(gameObject, "Planet", whiskerDirection, whiskerLength))
        {
            Debug.Log("Goal Detected");
            rayColor = Color.green;
            hitResult = true;
        }

        // Debug ray visualization
        Debug.DrawRay(transform.position, whiskerDirection * whiskerLength, rayColor);
        return hitResult;
    }
    // there are hidden commented COMMENTS LOOK CAREFULLY U ARE GONNA SEE THEM OPEN THEM (THEY ARE IN OTHER SCRIPTS TOO)
    // TODO: Comment out method for Lab 6a.
    /*    private void SeekForward() // A seek with rotation to target but only moving along forward vector.
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
        }*/// OPEN HERE FOR COMMENTED OUT CODES 

    // TODO: Comment out method for Lab 6a.
    /*    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Target")
            {
                GetComponent<AudioSource>().Play();
            }
        }
    */// OPEN HERE FOR COMMENTED OUT CODES 
}
