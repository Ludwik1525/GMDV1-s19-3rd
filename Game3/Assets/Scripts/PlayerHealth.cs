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
	private Transform _healtBarTransform,_teamHealthbar, _team;


	//Using awake to set the health number on the player prefabs
	void Awake()
	{
		
		playerHp = 100;
	}

	// Use this for initialization
	void Start () {
		
		user = GetComponent<Rigidbody2D>();
		playerHp = 100f;
		print(playerHp + this.name);
		takeDmg(50);
		// setSizeOfHpBar();
		
	}

	void update(){
		
	}	

    public void takeDmg(float dmg)
    {
		
		_team = transform.Find("/Main Camera").GetComponent<Transform>();
		Transform camHealthbar = _team.Find("Healthbar").GetComponent<Transform>();
		teamHealth = camHealthbar.GetComponent<TeamHealth>();		
        playerHp -= dmg;
        Debug.Log(playerHp);
		teamHealth.setSize(dmg);
		setSizeOfHpBar();
    }

	public float getPlayerHp(){
		return playerHp;
	}

	public void setPlayerHp(float value){
        playerHp = value;
	}

	void setSizeOfHpBar(){
		Transform bar;		
		_healtBarTransform = transform.GetComponentInChildren<Transform>().Find("HealthbarPlayer");
		bar = _healtBarTransform.GetComponentInChildren<Transform>().Find("Bar");		
		bar.localScale = new Vector3(playerHp/100, 1f);
	}
	
}
