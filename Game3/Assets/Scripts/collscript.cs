using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		GameObject player;
		print("in coll");
		if(other.collider.CompareTag("Player")){
			player = other.gameObject.GetComponent<GameObject>();
			print(player.name);
		}
	}
}
