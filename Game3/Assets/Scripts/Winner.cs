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
    public GameObject counter;
    public bool hasGameEnded = false;

    void Start () {
    }
	
	void Update () {
		
        if (hasGameEnded)
        {
            pauseStuff.gameObject.SetActive(false);
            counter.gameObject.SetActive(false);
            Time.timeScale = 0.0f;
            winningStuff.gameObject.SetActive(true);
            if (redWon)
            {
                red.gameObject.SetActive(true);
                blue.gameObject.SetActive(false);
            }
            else
            {
                red.gameObject.SetActive(false);
                blue.gameObject.SetActive(true);
            }
        }

        exit.onClick.AddListener(BackToMenu);

	}

    void BackToMenu()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
    }
}
