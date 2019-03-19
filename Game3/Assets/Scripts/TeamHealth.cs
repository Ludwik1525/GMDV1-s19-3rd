using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamHealth : MonoBehaviour {

	
	[SerializeField]private PlayerHealth playerHealth;
	private Transform bar;
	private float _totalHpFirst,_totalHp,timesSet;
	public int numberOfPlayers;
	
	
	void Awake(){
		_totalHpFirst = 200;
		_totalHp = 100;
		timesSet = 1;
	}
	// Use this for initialization
	void Start () {
		
		setTotalHp();
		
		
	}

	//Sets the size of the bar gameobject which is representing the healthbar of the teams
	//method should perhaps be called setHealth
	public void setSize(float dmg){
		bar = this.transform.Find("Bar");
		float relation = 0;
		//Might not need this check since it starts at 100%
		

		if(timesSet < 1){			
			_totalHpFirst = _totalHp;
			bar.localScale = new Vector3((1f),1f);			
			timesSet++;			

		}else {
			print(_totalHp + "total hp");
			print(_totalHpFirst + "total hp first");

		_totalHp -= dmg;
		relation = _totalHp/_totalHpFirst;
		bar.localScale = new Vector3((relation), 1f);
		}
			
		
	}	
	

	//should probably be executed every time a shot has been fired.
	public void setTotalHp(){				
		numberOfPlayers = 0;
		Transform teamTrans = transform.Find("/Team").GetComponent<Transform>();		
			foreach(Transform playertrans in teamTrans){
				
				if(playertrans.CompareTag("Player")){
			
				playerHealth = playertrans.GetComponent<PlayerHealth>();				
				_totalHp += playerHealth.getPlayerHp();				
				numberOfPlayers++;
				print(numberOfPlayers);
				}

			}

			// setSize(_totalHp / numberOfPlayers);
		
	}
}
