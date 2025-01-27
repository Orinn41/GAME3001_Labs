using System;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject characterPrefab;
    public GameObject targetPrefab;
    public GameObject enemyPrefab;
    public GameObject obstaclePrefab;

    private GameObject characterInstance;
    private GameObject targetInstance;
    private GameObject enemyInstance;
    private GameObject obstacleInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterPrefab.SetActive(false);
        targetPrefab.SetActive(false);  
        enemyPrefab.SetActive(false);
        obstaclePrefab.SetActive(false);
    }

    // Update is called once per frame
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
        characterInstance = Instantiate(characterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        targetInstance = Instantiate(targetPrefab, new Vector3(5,0, 5), Quaternion.identity);
        characterInstance.SetActive(true);
        targetInstance.SetActive(true);
        characterInstance.GetComponent<SeekingBehavior>().target = targetInstance.transform;
    }
    void StartFleeing()
    {
        characterInstance = Instantiate(characterPrefab, new Vector3(0,0,0), Quaternion.identity);
        enemyInstance = Instantiate(enemyPrefab, new Vector3(5, 0, 5),Quaternion.identity);
        characterInstance.SetActive(true);
        enemyInstance.SetActive(true);
        characterInstance.GetComponent<FleeingBehavior>().enemy = enemyInstance.transform;

    }
    void StartArrival()
    {
        characterInstance = Instantiate(characterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        targetInstance = Instantiate(targetPrefab, new Vector3(5, 0, 5), Quaternion.identity);
        characterInstance.SetActive(true);
        targetInstance.SetActive(true);
        characterInstance.GetComponent<ArrivalBehavior>().target = targetInstance.transform;
    }
    void StartAvoidance()
    {
        characterInstance = Instantiate(characterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        targetInstance = Instantiate(targetPrefab, new Vector3(5, 0, 5), Quaternion.identity);
        enemyInstance = Instantiate(enemyPrefab, new Vector3(2, 0, 2), Quaternion.identity);
        characterInstance.SetActive(true);
        enemyInstance.SetActive(true);
        targetInstance.SetActive(true);
        characterInstance.GetComponent<AvoidanceBehavior>().target = targetInstance.transform;
        characterInstance.GetComponent<AvoidanceBehavior>().enemy = enemyInstance.transform;

    }
    void ResetScene()
    {
        Destroy(characterInstance);
        Destroy(targetInstance);
        Destroy(enemyInstance);
        Destroy(obstacleInstance);
    }
}
