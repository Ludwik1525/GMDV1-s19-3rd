﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TurnMaker : MonoBehaviour
{

    public GameObject p0;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;

    public Text counter;
    public float tourTime;
    public bool end = false;
    private int currentP = 0;

    public string teamColor;

    private GameObject player;
    private Vector3 offset;

    public GameObject winningStuff;
    public Button exit;
    public Text green;
    public Text blue;
    public bool greenWon = false;
    public GameObject pauseStuff;
    public PauseGame pauseGame;

    void Start()
    {
        counter.text = "" + (tourTime + 1);
        StartCoroutine(Counter(tourTime, counter));

        p0.transform.position = new Vector2(Random.Range(-20.0f, 20.0f), 4);
        p1.transform.position = new Vector2(Random.Range(-20.0f, 20.0f), 4);
        p2.transform.position = new Vector2(Random.Range(-20.0f, 20.0f), 4);
        p3.transform.position = new Vector2(Random.Range(-20.0f, 20.0f), 4);
        p4.transform.position = new Vector2(Random.Range(-20.0f, 20.0f), 4);
        p5.transform.position = new Vector2(Random.Range(-20.0f, 20.0f), 4);

        
        exit.onClick.AddListener(BackToMenu);
    }
    void Update(){

    
        if (end)
        {
            StopAllCoroutines();
            counter.color = Color.white;
            counter.text = "" + (tourTime+1);
            StartCoroutine(Counter(tourTime, counter));
            player.GetComponent<PlayerHealth>().Counter();
            currentP++;
            end = false;
        }

        switch (currentP%6)
        {
            case 0:
                if (p0.GetComponent<PlayerHealth>().deadOrNot == false)
                {
                    EnablePlayer(p0);
                    DisablePlayer(p1);
                    DisablePlayer(p2);
                    DisablePlayer(p3);
                    DisablePlayer(p4);
                    DisablePlayer(p5);
                    teamColor = "Blue";
                    player = p0;
                }
                else
                {
                    currentP+=2;
                }

                break;
            case 1:
                if (p1.GetComponent<PlayerHealth>().deadOrNot == false)
                {
                    EnablePlayer(p1);
                    DisablePlayer(p0);
                    DisablePlayer(p2);
                    DisablePlayer(p3);
                    DisablePlayer(p4);
                    DisablePlayer(p5);
                    teamColor = "Green";
                    player = p1;
                }
                else
                {
                    currentP += 2;
                }

                break;
            case 2:
                if (p2.GetComponent<PlayerHealth>().deadOrNot == false)
                {
                    EnablePlayer(p2);
                    DisablePlayer(p1);
                    DisablePlayer(p0);
                    DisablePlayer(p3);
                    DisablePlayer(p4);
                    DisablePlayer(p5);
                    teamColor = "Blue";
                    player = p2;
                }
                else
                {
                    currentP += 2;
                }

                break;
            case 3:
                if (p3.GetComponent<PlayerHealth>().deadOrNot == false)
                {
                    EnablePlayer(p3);
                    DisablePlayer(p1);
                    DisablePlayer(p2);
                    DisablePlayer(p0);
                    DisablePlayer(p4);
                    DisablePlayer(p5);
                    teamColor = "Green";
                    player = p3;
                }
                else
                {
                    currentP += 2;
                }

                break;
            case 4:
                if (p4.GetComponent<PlayerHealth>().deadOrNot == false)
                {
                    EnablePlayer(p4);
                    DisablePlayer(p1);
                    DisablePlayer(p2);
                    DisablePlayer(p3);
                    DisablePlayer(p0);
                    DisablePlayer(p5);
                    teamColor = "Blue";
                    player = p4;
                }
                else
                {
                    currentP += 2;
                }

                break;
            case 5:
                if (p5.GetComponent<PlayerHealth>().deadOrNot == false)
                {
                    EnablePlayer(p5);
                    DisablePlayer(p1);
                    DisablePlayer(p2);
                    DisablePlayer(p3);
                    DisablePlayer(p4);
                    DisablePlayer(p0);
                    teamColor = "Green";
                    player = p5;
                }
                else
                {
                    currentP += 2;
                }

                break;
        }

        if ((p0.GetComponent<PlayerHealth>().deadOrNot&& p2.GetComponent<PlayerHealth>().deadOrNot&& p4.GetComponent<PlayerHealth>().deadOrNot)||(p1.GetComponent<PlayerHealth>().deadOrNot&& p3.GetComponent<PlayerHealth>().deadOrNot&& p5.GetComponent<PlayerHealth>().deadOrNot))
        {
            if ((p0.GetComponent<PlayerHealth>().deadOrNot && p2.GetComponent<PlayerHealth>().deadOrNot &&
                 p4.GetComponent<PlayerHealth>().deadOrNot))
            {
                greenWon = true;
            }

            pauseStuff.gameObject.SetActive(false);
            counter.gameObject.SetActive(false);
            winningStuff.gameObject.SetActive(true);
            
                green.gameObject.SetActive(greenWon);
                blue.gameObject.SetActive(!greenWon);
           
            Time.timeScale = 0.0f;
        }

    }

    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(offset.x, offset.y, transform.position.z);
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
            yield return new WaitForSeconds(1f);
        }
    }

    public void EnablePlayer(GameObject player)
    {
        player.GetComponent<PlayerMovement>().keyFunctionOpen = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerShooting>().enabled = true;
        player.GetComponent<PlayerShooting>().playerPos.gameObject.SetActive(true);
        player.GetComponent<PlayAnim>().enabled = true;
        player.GetComponent<PlayAnim>().isIdle = false;
        //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation; 
    }


    public void DisablePlayer(GameObject player)
    {
        player.GetComponent<PlayerMovement>().keyFunctionOpen = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerShooting>().enabled = false;
        player.GetComponent<PlayerShooting>().playerPos.gameObject.SetActive(false);
        player.GetComponent<PlayAnim>().enabled = false;
        player.GetComponent<PlayAnim>().isIdle = true;
        //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public string GetColor()
    {
        return teamColor;
    }

    void BackToMenu()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
    }
}
