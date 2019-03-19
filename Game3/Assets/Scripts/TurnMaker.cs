﻿using System.Collections;
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
    public bool end = false;
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
                EnablePlayer(p0);
                DisablePlayer(p1);
                break;
            case 1:
                DisablePlayer(p0);
                EnablePlayer(p1);
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

    public void EnablePlayer(GameObject player)
    {
        player.GetComponent<PlayerMovement>().keyFunctionOpen = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShooting>().enabled = true;
        player.GetComponent<PlayAnim>().enabled = true;
        player.GetComponent<PlayAnim>().isIdle = false;
    }


    public void DisablePlayer(GameObject player)
    {
        player.GetComponent<PlayerMovement>().keyFunctionOpen = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerShooting>().enabled = false;
        player.GetComponent<PlayAnim>().enabled = false;
        player.GetComponent<PlayAnim>().isIdle = true;
    }
}
