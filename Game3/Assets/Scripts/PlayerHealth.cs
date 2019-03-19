using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]private TeamHealth teamHealth;
	private Canvas _canvas;
	private Text _hp;
	private Rigidbody2D user;
	private float playerHp;
	private GameObject canvasObject;
	private RectTransform rectTranny;


	//Using awake to set the health number on the player prefabs
	void Awake()
	{
		print("Awake");
		playerHp = 100;
	}

	// Use this for initialization
	void Start () {
		print("Start playerHealth");
		user = GetComponent<Rigidbody2D>();
		playerHp = 100f;
		print(playerHp + this.name);
	}

	void update(){
		print("got to the update");
	}	

    public void takeDmg(float dmg)
    {
        playerHp -= dmg;
        Debug.Log(playerHp);
    }

	public float getPlayerHp(){
		return playerHp;
	}

	public void setPlayerHp(float value){
        playerHp = value;
	}

	private void adjustHpText()
	{
		Transform tranny = this.transform;
	}
	
}
