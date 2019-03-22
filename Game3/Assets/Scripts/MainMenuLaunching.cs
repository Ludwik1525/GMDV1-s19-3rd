using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLaunching : MonoBehaviour
{
    public GameObject menuStuff;

    void Start()
    {
        Time.timeScale = 1f;
        menuStuff.gameObject.SetActive(false);
        StartCoroutine(Counter(3.5f));
        
    }

    void Update()
    {

    }

    public IEnumerator Counter(float t)
    {
        yield return new WaitForSeconds(t);

        menuStuff.gameObject.SetActive(true);
    }
}


