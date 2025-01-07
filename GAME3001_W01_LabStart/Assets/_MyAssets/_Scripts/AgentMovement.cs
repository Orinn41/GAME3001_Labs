using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgentMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Transform Island;
    [SerializeField]
    private float endSceneIslandDistance;

    private Vector3 targetPosition = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        // checking mouse clicks 
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse has been clicked");
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // convert mouse position to world position
            targetPosition.z = 0f; // ensure the Z-cordinate is correct for 2D game 
        }
        // move towards to target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        // rotate to look at target location 
        LookAt2D(targetPosition);

        if (Vector3.Distance(transform.position, Island.position) <= endSceneIslandDistance)
        {
            SceneManager.LoadScene(2);
        }
    }
    void LookAt2D(Vector3 target)
    { 
       Vector3 lookDirection = target - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
