using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamHealth : MonoBehaviour {

	
	[SerializeField]private PlayerHealth playerHealth;
	private Transform bar;
	private float _totalHpFirst,_totalHp;
	public Text healthbarText;

    private TurnMaker turnMaker;
    private string teamColor;
	
	void Awake(){
		//these variables are just to simulate round 2
		_totalHpFirst = 0;
		_totalHp = 0;
        turnMaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TurnMaker>();
        
		
    }
	// Use this for initialization
	void Start ()
    {
        
        setTotalHp();
    }

    void Update()
    {
        // teamColor = turnMaker.GetColor();
    }
	//Sets the size of the bar gameobject which is representing the healthbar of the teams
	//method should perhaps be called setHealth
	public void setSize(float dmg)
	{		
		bar = this.transform.Find("Bar");
		Canvas hpCanvas = this.transform.Find("TeamBarCanvas").GetComponent<Canvas>();
		healthbarText = hpCanvas.GetComponentInChildren<Text>();
		float relation = 0;
		
		if(_totalHp > _totalHpFirst){
			_totalHpFirst = _totalHp;
		}
		else {

		_totalHp -= dmg;
		}
		print(_totalHp + "total");
		print(_totalHpFirst + "first");
		relation = _totalHp/_totalHpFirst;
		print(relation);
		bar.localScale = new Vector3((relation), 1f);			
		healthbarText.text = (relation * 100) + "%";
		
	}	
	
	public void setTotalHp(){
       //Check here if there any active players and go to win scene
				// print(transform.name);
				
				string teamBlue = "Blue";
				string teamGreen = "Green";
				string team = "Team";
				string teamColor = transform.name.Substring(9);
				
			//solution is to move the script to the camera 

				
			// foreach(Transform playertrans in transform){
				
			// 	//maybe make check to see if found player is "active"
			// 	if(playertrans.CompareTag("Player")){
			// 		print(playertrans.name + "player tranny");
			// 	playerHealth = playertrans.GetComponent<PlayerHealth>();				
					
			// 	_totalHp += playerHealth.getPlayerHp();	
					
			// 	}

			// }
			print(_totalHp);
			print(_totalHpFirst);
			_totalHpFirst = _totalHp;		

	}
	//you just need to use this method to determine the current team name
	//then you have to use this method in "SettotalHp" so that the method can see what team healthbar to manipulate
	public string lookForTeam(string teamColor){
		if(teamColor == "Blue"){
			return "TeamBlue";
		}else {
			return "TeamGreen";
		}


	}
	
}
