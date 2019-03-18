using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{
    public GameObject winningStuff;
    public Button exit;
    public Text red;
    public Text blue;
    public bool redWon = false;
    public GameObject pauseStuff;

    void Start () {
        Time.timeScale = 0.0f;
    }
	
	void Update () {
		
        pauseStuff.gameObject.SetActive(false);

        //if(game has ended)
        //{
        //    winningStuff.gameObject.SetActive(true);
        //    if (redWon)
        //    {
        //        red.gameObject.SetActive(true);
        //        blue.gameObject.SetActive(false);
        //    }
        //    else
        //    {
        //        red.gameObject.SetActive(false);
        //        blue.gameObject.SetActive(true);
        //    }
        //}

        exit.onClick.AddListener(BackToMenu);

	}

    void BackToMenu()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
    }
}
