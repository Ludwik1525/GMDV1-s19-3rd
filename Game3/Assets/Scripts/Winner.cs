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
    private TeamHealth teamHealth;

    void Start ()
    {
        teamHealth = GetComponent<TeamHealth>();
    }
	
	void Update () {
        
        if (teamHealth.HP < 10f && teamHealth.teamColor == "Green")
        {
            hasGameEnded = true;
            greenWon = true;
        }
        else if(teamHealth.HP < 10f && teamHealth.teamColor == "Blue")
        {
            hasGameEnded = true;
            greenWon = false;
        }

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

            hasGameEnded = false;
        }

        exit.onClick.AddListener(BackToMenu);

	}

    void BackToMenu()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
    }
}
