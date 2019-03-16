using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamHealth : MonoBehaviour {

	private Transform bar;

	// Use this for initialization
	void Start () {
		 bar = transform.Find("Bar");
		
		
	}

	public void setSize(float sizeNormalized){
		bar.localScale = new Vector3(sizeNormalized,1f);
		print("Hey you did it son");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
