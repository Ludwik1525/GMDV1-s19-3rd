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
		_totalHp = 50;
		timesSet = 1;
	}
	// Use this for initialization
	void Start () {
		setTotalHp();
	}

	//Sets the size of the bar gameobject which is representing the healthbar of the teams
	//method should perhaps be called setHealth
	public void setSize(float dmg)
	{		
		bar = this.transform.Find("Bar");
		float relation = 0;
		//how to return to this flow after settotalhp is done - coroutine?
		

		if(timesSet < 1){			
			_totalHpFirst = _totalHp;
			bar.localScale = new Vector3((1f),1f);			
			timesSet++;			

		}
		else 
		{	

		_totalHp -= dmg;
		print(_totalHp + "total hp in setsize");
		print(_totalHpFirst);
		relation = _totalHp/_totalHpFirst;
		bar.localScale = new Vector3((relation), 1f);
		print(bar.localScale + "after relation");
		}
			
		
	}	
	

	//should probably be executed every time a shot has been fired.
	public void setTotalHp(){
		print("settotalHpStarted");				
		numberOfPlayers = 0;
		Transform teamTrans = transform.Find("/Team").GetComponent<Transform>();		
			foreach(Transform playertrans in teamTrans){
				
				//make check to see if found player is "active"
				if(playertrans.CompareTag("Player")){
			
				playerHealth = playertrans.GetComponent<PlayerHealth>();
				print(playerHealth + "playerhealth name");
				print(_totalHp + "this is total hp in settotalhp");
					if(playerHealth.getPlayerHp() == 0){
						//do nothing I guess
					}
								
						//there is an error here
					_totalHp += playerHealth.getPlayerHp();				
				print(playerHealth.getPlayerHp() + "getplayerhealth");
					numberOfPlayers++;
				}

			}		

	}
	// public IEnumerator setTotalHpCo(){
	// 	print("settotalHpStarted");				
	// 	numberOfPlayers = 0;
	// 	Transform teamTrans = transform.Find("/Team").GetComponent<Transform>();		
	// 		foreach(Transform playertrans in teamTrans){
				
	// 			//make check to see if found player is "active"
	// 			if(playertrans.CompareTag("Player")){
			
	// 			playerHealth = playertrans.GetComponent<PlayerHealth>();
	// 			print(playerHealth + "playerhealth name");
	// 			print(_totalHp + "this is total hp");
	// 				if(playerHealth.getPlayerHp() == 0){
	// 					//do nothing I guess
						
	// 				} else
								
	// 					//there is an error here
	// 				_totalHp += playerHealth.getPlayerHp();				
	// 			print(playerHealth.getPlayerHp() + "getplayerhealth");
	// 				numberOfPlayers++;
	// 			}

	// 		}		

	// 	StopCoroutine(setTotalHpCo());
	// 	yield return null;
	// }
}
