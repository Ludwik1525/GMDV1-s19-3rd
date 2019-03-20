using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamHealth : MonoBehaviour {

	
	[SerializeField]private PlayerHealth playerHealth;
	public Transform bar;
	private float _totalHpFirst,_totalHp;

    private TurnMaker turnMaker;
    public string teamColor;

    public float HP;

	void Awake(){
		//these variables are just to simulate round 2
		_totalHpFirst = 200;
		_totalHp = 0;
        turnMaker = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TurnMaker>();
        teamColor = turnMaker.GetColor();
    }
	// Use this for initialization
	void Start ()
    {
        print(teamColor + "this weird");
        setTotalHp(teamColor);
    }

    void Update()
    {
        teamColor = turnMaker.GetColor();
        HP = _totalHp;
    }
	//Sets the size of the bar gameobject which is representing the healthbar of the teams
	//method should perhaps be called setHealth
	public void setSize(float dmg)
	{		
		bar = this.transform.Find("Bar");
		float relation = 0;	
		_totalHp -= dmg;		
		relation = _totalHp/_totalHpFirst;
		bar.localScale = new Vector3((relation), 1f);			
		
	}	
	
	public void setTotalHp(string teamColor){
        print(teamColor +"teamcolor");
                print(transform.Find("/Team" + teamColor).GetComponent<Transform>());
		Transform teamTrans = transform.Find("/Team" + teamColor).GetComponent<Transform>();		
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
