using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private Canvas _canvas;
	private Text _hp;
	private int _hpNumber;
	public GameObject user;
	private GameObject canvasObject;
	private RectTransform rectTranny;


	//Using awake to set the health number on the player prefabs
	void Awake()
	{
		print("Awake");
		_hpNumber = 100;
	}
	// Use this for initialization
	void Start () {
		print("Start");
		user = GetComponent<GameObject>();
		print(user);
		AddCanvasAndText();
	}

	void AddCanvasAndText()
	{
		print("addCanvasReached");
		if(user){
			print("Hey");
			print(user.GetComponent<GameObject>());
		}
	}
	
	
}
