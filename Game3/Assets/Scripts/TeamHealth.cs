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
		_totalHpFirst = 300;
		_totalHp = 300;
        turnMaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TurnMaker>();
        
		
    }
	// Use this for initialization
	void Start ()
    {
        
        // setTotalHp(teamColor);
    }

    void Update()
    {
        teamColor = turnMaker.GetColor();
    }
	//Sets the size of the bar gameobject which is representing the healthbar of the teams
	//method should perhaps be called setHealth
	public void setSize(float dmg)
	{		
		bar = this.transform.Find("Bar");
		Canvas hpCanvas = this.transform.Find("TeamBarCanvas").GetComponent<Canvas>();
		healthbarText = hpCanvas.GetComponentInChildren<Text>();
		float relation = 0;	
		_totalHp -= dmg;		
		relation = _totalHp/_totalHpFirst;
		bar.localScale = new Vector3((relation), 1f);			
		healthbarText.text = (relation * 100) + "%";
		
	}	
	
	public void setTotalHp(){
       
		Transform teamTrans = transform.Find("/Team").GetComponent<Transform>();		
			foreach(Transform playertrans in teamTrans){
				
				//maybe make check to see if found player is "active"
				if(playertrans.CompareTag("Player")){
			
				playerHealth = playertrans.GetComponent<PlayerHealth>();				
					
				_totalHp += playerHealth.getPlayerHp();	
					
				}

			}
			_totalHpFirst = _totalHp;		

	}
	
}
