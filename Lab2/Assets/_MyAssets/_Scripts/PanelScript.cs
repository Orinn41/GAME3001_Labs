using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public GameObject panel;
    public Button restartButton;

    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
        isPaused = true;
    }
    void ContinueGame()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        isPaused = false;
    }
    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


