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
    public Slider sliderMusic;
    public Slider sliderSounds;

    void Start () {
		pauseStuff.gameObject.SetActive(false);
        sliderMusic.value = 0.5f;
        sliderSounds.value = 0.5f;
        resume.onClick.AddListener(Resume);
        menu.onClick.AddListener(GoToMenu);
}
	
	void Update () {


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
        GetComponent<AudioSource>().volume = sliderMusic.value;
        GameObject.FindGameObjectWithTag("Bckg").GetComponent<AudioSource>().volume = sliderSounds.value;
    }

    void Resume()
    {
        pauseStuff.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
    }

   void GoToMenu()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
    }
}
