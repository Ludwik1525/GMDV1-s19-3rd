using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]private TeamHealth teamHealth;
	[SerializeField] private  TurnMaker turnMaker;
	private Rigidbody2D user;
	private float playerHp;
	private Transform _healtBarTransform,_teamHealthbar, _team, _camHealthbar;
    public bool deadOrNot;
   
    void Awake()
	{		
		playerHp = 100;
        deadOrNot = false;
    }

	// Use this for initialization
	void Start () {

        
        user = GetComponent<Rigidbody2D>();
		playerHp = 100f;
		checkTeam();
		turnMaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TurnMaker>();
		
	}

	void Update(){
		isDead();
        //check to see if the player is out of bounds
		
    }	

    public void takeDmg(float dmg)
    {
		_team = transform.Find("/Main Camera").GetComponent<Transform>();
		if(checkTeam()){
			 _camHealthbar = _team.Find("HealthbarGreen").GetComponent<Transform>();
		}
		else{

		 _camHealthbar = _team.Find("HealthbarBlue").GetComponent<Transform>();
		}        
		teamHealth = _camHealthbar.GetComponent<TeamHealth>();
		
		if(playerHp - dmg < 0){
			playerHp = 0f;
		}else{

        playerHp -= dmg;
		}
	
		teamHealth.setSize(dmg);
		setSizeOfHpBar();
		
    }

	public float getPlayerHp(){
		return playerHp;
	}

	void setSizeOfHpBar(){
		Transform bar;
			
		_healtBarTransform = transform.GetComponentInChildren<Transform>().Find("HealthbarPlayer");
		
		bar = _healtBarTransform.GetComponentInChildren<Transform>().Find("Bar");
				
		bar.localScale = new Vector3(playerHp/100, 1f);
	
	}

	public bool checkTeam(){
		 int team;
		string playerName = this.name;
		// string resultString = Regex.Match(playerName, @"\d+").Value;
		int.TryParse(Regex.Match(playerName, @"\d+").Value,out team);
		
		if(team % 2 == 1){
			return true;
		}

		
		return false;
	}

		void isDead(){

		bool isActive = transform.GetComponent<PlayerMovement>().isActiveAndEnabled;
			if(playerHp <= 0 || transform.position.y <=-5 && !isActive){
				//what happens if the player has 150hp?
				takeDmg(playerHp);
				this.gameObject.SetActive(false);
				// turnMaker.end = true;
				deadOrNot = true;
				
			}
			else if (playerHp <= 0 || transform.position.y <=-5 && isActive){
				takeDmg(playerHp);
				this.gameObject.SetActive(false);
				// turnMaker.end = true;
				deadOrNot = true;
				turnMaker.end = true;
			}
		}
		
	}
	

