using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collscript : MonoBehaviour {

	[SerializeField]PlayerHealth playerhp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other){
		Transform player;
		
		if(other.collider.CompareTag("Player")){
			player = other.gameObject.GetComponent<Transform>();
			playerhp = player.GetComponent<PlayerHealth>();
			playerhp.takeDmg(-25);
			gameObject.SetActive(false);
		}
	}
}
