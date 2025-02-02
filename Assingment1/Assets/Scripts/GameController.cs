using System;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject object0;
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private GameObject object3;
    public GameObject characterPrefab;
    public GameObject targetPrefab;
    public GameObject enemyPrefab;
    public GameObject obstaclePrefab;

    private List<GameObject> instantiatedObjects = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetAllObjectsInactive();
        characterPrefab.SetActive(false);
        targetPrefab.SetActive(false);  
        enemyPrefab.SetActive(false);
        obstaclePrefab.SetActive(false);
    }
    public void SetAllObjectsInactive()
    {
        object0.SetActive(false);
        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(false);
    }
    public void SetObject0Active()
    {
        object0.SetActive(true);
    }
    public void setObject1Active()
    {
        object1.SetActive(true);
    }
    public void setObject2Active()
    {
        object2.SetActive(true);
    }
    public void setObject3Active()
    {
        object3.SetActive(true);
    }
    public void MoveObjectsRandom()
    {
        object0.transform.position = GetRandomPosition();
        object1.transform.position = GetRandomPosition();
        object2.transform.position = GetRandomPosition();
        object3.transform.position = GetRandomPosition();
    }
    private Vector3 GetRandomPosition()
    {
        float x = UnityEngine.Random.Range(-5f, 5f);
        float y = UnityEngine.Random.Range(-5f, 5f);
        float z = 0;
        return new Vector3(x, y, z);
    }
    // Update i
    // s called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) StartSeeking();
        if (Input.GetKeyDown(KeyCode.Alpha2)) StartFleeing();
        if (Input.GetKeyDown(KeyCode.Alpha3)) StartArrival();
        if (Input.GetKeyDown(KeyCode.Alpha4)) StartAvoidance();
        if (Input.GetKeyDown(KeyCode.Alpha0)) ResetScene();
    }
    void StartSeeking()
    {
        GameObject characterInstance = Instantiate(characterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject targetInstance = Instantiate(targetPrefab, new Vector3(5,0, 0), Quaternion.identity);
        characterInstance.SetActive(true);
        targetInstance.SetActive(true);
        characterInstance.GetComponent<SeekingBehavior>().target = targetInstance.transform;
        instantiatedObjects.Add(characterInstance);
        instantiatedObjects.Add(targetInstance);
    }
    void StartFleeing()
    {
        GameObject characterInstance = Instantiate(characterPrefab, new Vector3(0,0,0), Quaternion.identity);
        GameObject enemyInstance = Instantiate(enemyPrefab, new Vector3(5, 0, 0),Quaternion.identity);
        characterInstance.SetActive(true);
        enemyInstance.SetActive(true);
        characterInstance.GetComponent<FleeingBehavior>().enemy = enemyInstance.transform;
        instantiatedObjects.Add(characterInstance);
        instantiatedObjects.Add(enemyInstance);

    }
    void StartArrival()
    {
        GameObject characterInstance = Instantiate(characterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject targetInstance = Instantiate(targetPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        characterInstance.SetActive(true);
        targetInstance.SetActive(true);
        characterInstance.GetComponent<ArrivalBehavior>().target = targetInstance.transform;
        instantiatedObjects.Add(characterInstance);
        instantiatedObjects.Add(targetInstance);
    }
    void StartAvoidance()
    {
        GameObject characterInstance = Instantiate(characterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject  targetInstance = Instantiate(targetPrefab, new Vector3(5, 0, 0), Quaternion.identity);
        GameObject enemyInstance = Instantiate(enemyPrefab, new Vector3(2, 0, 0), Quaternion.identity);
        characterInstance.SetActive(true);
        enemyInstance.SetActive(true);
        targetInstance.SetActive(true);
        characterInstance.GetComponent<AvoidanceBehavior>().target = targetInstance.transform;
        characterInstance.GetComponent<AvoidanceBehavior>().enemy = enemyInstance.transform;
        instantiatedObjects.Add(characterInstance);
        instantiatedObjects.Add(targetInstance);
        instantiatedObjects.Add(enemyInstance);

    }
    void ResetScene()
    {
      foreach(GameObject obj  in instantiatedObjects)
        {
            if ( obj != null)
              Destroy(obj);
        }
      instantiatedObjects.Clear();
    }
}
