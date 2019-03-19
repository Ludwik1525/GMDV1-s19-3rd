using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustHpText : MonoBehaviour {

	private Transform playerTrans;
	private Text hpText;
	private Vector3 playerpos, playerPos;
	
	void Start(){
		
		playerTrans = GetComponent<Transform>();
		playerpos = playerTrans.position;
		hpText = playerTrans.GetComponentInChildren<Text>();
		
	}
	// Update is called once per frame
	void Update () {
		playerPos = playerTrans.position;
		float y = hpText.transform.position.y;

		hpText.transform.position = playerPos;
		
		//print(hpText.transform.position + "hptext position");
	}
}
