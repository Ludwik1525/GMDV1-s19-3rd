using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnMaker : MonoBehaviour
{

    public GameObject p0;
    public GameObject p1;
    //public GameObject p2;
    //public GameObject p3;
    //public GameObject p4;
    //public GameObject p5;

    public Text counter;
    public float tourTime;
    private bool end = false;
    private int currentP = 0;

    void Start()
    {
        counter.text = "" + (tourTime + 1);
        StartCoroutine(Counter(tourTime, counter));
    }

    void Update()
    {
        if (end)
        {
            StopAllCoroutines();
            counter.color = Color.white;
            counter.text = "" + (tourTime+1);
            StartCoroutine(Counter(tourTime, counter));
            currentP++;
            end = false;
        }

        switch (currentP%2)
        {
            case 0:
                p0.GetComponent<PlayerMovement>().enabled = true;
                p1.GetComponent<PlayerMovement>().enabled = false;
                break;
            case 1:
                p0.GetComponent<PlayerMovement>().enabled = false;
                p1.GetComponent<PlayerMovement>().enabled = true;
                break;
        }
    }

    public IEnumerator Counter(float t, Text i)
    {
        while (int.Parse(i.text) >= -1)
        {
            i.text = "" + (int.Parse(i.text) - 1);
            if (int.Parse(i.text) < 6)
            {
                i.color = Color.red;
            }
            if (int.Parse(i.text) == -1)
            {
                end = true;
            }
            yield return new WaitForSeconds(1);
        }
    }


}
