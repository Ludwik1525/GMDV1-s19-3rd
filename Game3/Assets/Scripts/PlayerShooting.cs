using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bullet;
    public Transform playerPos, directionPos;
    public float powerModifier;

    float power = 0;
    Vector3 rightRotation, leftRotation;
    Vector2 shootVector;
    bool shooting = false;

    private TurnMaker turnMaker;
    
	void Start () {
        rightRotation = new Vector3(0, 0, 1.75f);
        leftRotation = new Vector3(0, 0, -1.75f);
        turnMaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TurnMaker>();
    }
	
	void Update () {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(playerPos.transform.rotation.z < 0.7)
            {
                playerPos.Rotate(rightRotation);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if(playerPos.transform.rotation.z > -0.45)
            {
                playerPos.Rotate(leftRotation);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!shooting)
            {
                shootVector = (directionPos.position - playerPos.position).normalized;
                shooting = true;
                StartCoroutine("ShootingRoutine");
            }
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            StopCoroutine("ShootingRoutine");
            GameObject bulletShot = Instantiate(bullet, (Vector2)transform.position + (shootVector * 0.6f), transform.rotation);
            Rigidbody2D bulletBody = bulletShot.GetComponent<Rigidbody2D>();
            bulletBody.velocity = shootVector * power;
            power = 0;
            shooting = false;
            turnMaker.end = true;
        }
    }

    private IEnumerator ShootingRoutine()
    {
        while (true)
        {
            power += powerModifier;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
