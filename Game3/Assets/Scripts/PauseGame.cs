using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{

    public GameObject pauseStuff;
    private bool isPaused = false;
    public Button resume;
    public Button menu;

	void Start () {
		pauseStuff.gameObject.SetActive(false);
	}
	
	void Update () {

        resume.onClick.AddListener(Resume);
        menu.onClick.AddListener(GoToMenu);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                pauseStuff.SetActive(true);
                isPaused = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                pauseStuff.SetActive(false);
                isPaused = false;
                Time.timeScale = 1.0f;
            }
        }
	}

    void Resume()
    {
        pauseStuff.SetActive(false);
        isPaused = false;
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
