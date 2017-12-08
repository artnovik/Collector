using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    private
        bool isGameRunning;

    public GameObject DeadMenu, PauseMenu, playerObj;

    // Use this for initialization
    void Start() {
        DeadMenu.SetActive(false);
        PauseMenu.SetActive(false);
        isGameRunning = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            ShowPauseMenu();
    }

    void ShowPauseMenu()
    {
        if (isGameRunning && !playerObj.GetComponent<PlayerController>().isDead)
        {
            isGameRunning = false;
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else if (!isGameRunning && !playerObj.GetComponent<PlayerController>().isDead)
        {
            isGameRunning = true;
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }

    public void ShowDeadMenu()
    {
        Time.timeScale = 0;
        DeadMenu.SetActive(true);

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Resume()
    {
        isGameRunning = true;
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
