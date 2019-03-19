using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{

    public Button startB;
    public Button controls;
    public Button optionsB;
    public Button exitB;
    public Button back;
    public Button backA;
    public Slider slider;

    //public GameObject options;
    public GameObject mainStuff;
    public GameObject controlsStuff;

    void Start () {
        //options.gameObject.SetActive(false);
        controlsStuff.gameObject.SetActive(false);
        slider.value = 0.5f;
    }
	
	void Update () {
		
        startB.onClick.AddListener(StartGame);
        controls.onClick.AddListener(OpenControls);
        //optionsB.onClick.AddListener(OpenOptions);
        exitB.onClick.AddListener(QuitGame);
        //back.onClick.AddListener(GoBack);
        backA.onClick.AddListener(GoBackA);
        AudioListener.volume = slider.value;

    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void QuitGame()
    {
        Application.Quit();
    }

    //void OpenOptions()
    //{
    //    mainStuff.gameObject.SetActive(false);
    //    options.gameObject.SetActive(true);
    //}

    void OpenControls()
    {
        mainStuff.gameObject.SetActive(false);
        controlsStuff.gameObject.SetActive(true);
    }

    //void GoBack()
    //{
    //    options.gameObject.SetActive(false);
    //    mainStuff.gameObject.SetActive(true);
    //}

    void GoBackA()
    {
        controlsStuff.gameObject.SetActive(false);
        mainStuff.gameObject.SetActive(true);
    }

}
