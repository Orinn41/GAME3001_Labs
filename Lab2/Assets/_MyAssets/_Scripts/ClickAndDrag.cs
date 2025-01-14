using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;
    private Rigidbody2D currentlyDragObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if(hit.collider != null)
            {
                //Check if the clicked gameobject has a rigidBody2D
                Rigidbody2D rb2d = hit.collider.GetComponent<Rigidbody2D>();
                if(rb2d != null)
                {
                    // Start Draging only if no object is cuurently being dragged
                    isDragging = true;
                    currentlyDragObject = rb2d;
                    offset = rb2d.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            currentlyDragObject = null;
            isDragging = false;
        }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        currentlyDragObject.MovePosition(mousePosition + offset);
    }
}
