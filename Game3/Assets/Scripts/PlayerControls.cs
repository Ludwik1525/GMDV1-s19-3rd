using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	[SerializeField]public float moveSpeed,jumpHeight,moveHorizontal,moveHorizontalP2;
	[SerializeField]private Vector2 movement;
	[SerializeField]public TeamHealth teamHealth;
	public GameObject p1,p2;
	private Rigidbody2D player;
	public Rigidbody2D rgbd1,rgbd2;

	// Use this for initialization
	void Start () {
		p1 = GameObject.FindGameObjectWithTag("Player");
		p2 = GameObject.FindGameObjectWithTag("Player2");
		rgbd1 = p1.GetComponent<Rigidbody2D>();
		rgbd2 = p2.GetComponent<Rigidbody2D>();
		jumpHeight = 20;
		teamHealth.setSize(0.4f);
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveHorizontal = Input.GetAxis("Horizontal");
		moveHorizontalP2 = Input.GetAxis("HorizontalP2");
		
		if(Input.GetButtonDown("Jump")){
			rgbd1.AddForce(new Vector2(moveHorizontal,jumpHeight));
		}else if (Input.GetButtonDown("JumpP2")){
			rgbd2.AddForce(new Vector2(moveHorizontalP2,jumpHeight));
		}



		rgbd2.AddForce(new Vector2(moveHorizontalP2,0));	
		rgbd1.AddForce(new Vector2(moveHorizontal,0));


	}

}
