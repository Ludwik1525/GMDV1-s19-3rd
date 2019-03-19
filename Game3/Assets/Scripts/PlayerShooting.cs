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
    
	void Start () {
        rightRotation = new Vector3(0, 0, 1);
        leftRotation = new Vector3(0, 0, -1);
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerPos.Rotate(rightRotation);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            playerPos.Rotate(leftRotation);
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
