using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{
    public GameObject winningStuff;
    public Button exit;
    public Text green;
    public Text blue;
    public bool greenWon = false;
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
            if (greenWon)
            {
                green.gameObject.SetActive(true);
                blue.gameObject.SetActive(false);
            }
            else
            {
                green.gameObject.SetActive(false);
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
