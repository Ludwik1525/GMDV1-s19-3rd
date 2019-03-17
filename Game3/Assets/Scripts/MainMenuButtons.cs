using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{

    public Button startB;
    public Button optionsB;
    public Button exitB;
    public Button back;
    public Slider slider;

    public GameObject options;
    public GameObject mainStuff;

    void Start () {
        options.gameObject.SetActive(false);
        slider.value = 0.5f;
    }
	
	void Update () {
		
        startB.onClick.AddListener(StartGame);
        optionsB.onClick.AddListener(OpenOptions);
        exitB.onClick.AddListener(QuitGame);
        back.onClick.AddListener(GoBack);
        AudioListener.volume = slider.value;

    }

    void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void OpenOptions()
    {
        mainStuff.gameObject.SetActive(false);
        options.gameObject.SetActive(true);
    }

    void GoBack()
    {
        options.gameObject.SetActive(false);
        mainStuff.gameObject.SetActive(true);
    }
    
}
