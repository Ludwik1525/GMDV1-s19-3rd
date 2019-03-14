using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButton("Start_1"))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }
    }
}
