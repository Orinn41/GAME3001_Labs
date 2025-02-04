using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationObject : MonoBehaviour
{
    public Vector2 gridIndex;


    // Start is called before the first frame update
    void Start()
    {
        gridIndex = new Vector2();
        SetGridIndex();
        
    }
    public Vector2 GetGridIndex()
    {
        return gridIndex;
    }
    public void SetGridIndex()
    { 
        float originalX = Mathf.Floor(transform.position.x) + 0.5f;
        Debug.Log("Original X is," +originalX);
        gridIndex.x = Mathf.Floor((originalX + 7.5f) / 15 * 15);
        float originalY = Mathf.Floor(transform.position.y) + 0.5f;
        gridIndex.y = 11 - (int)Mathf.Floor((originalY + 5.5f));
    }
    

    // Update is called once per frame
    void Update()
    {
        SetGridIndex();
    }
}
