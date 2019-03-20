using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float radius;
    public float dmg;

    private TurnMaker turnMaker;
    private string teamColor;
    // Use this for initialization
    void Start () {

        turnMaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TurnMaker>();
        teamColor = turnMaker.GetColor();
    }
	
	// Update is called once per frame
	void Update () {

        teamColor = turnMaker.GetColor();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] inRadius = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D c in inRadius)
        {
            if (c.gameObject.CompareTag("Player"))
            {
                float distance = Vector2.Distance(transform.position, c.transform.position);
                c.GetComponent<PlayerHealth>().takeDmg(dmg/distance);
            }
        }
        Destroy(gameObject);
    }
}
