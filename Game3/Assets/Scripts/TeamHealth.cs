using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamHealth : MonoBehaviour {

	
	[SerializeField]private PlayerHealth playerHealth;
	public Transform bar;
	private float _totalHpFirst,_totalHp;

    private TurnMaker turnMaker;
    public string teamColor;

    public GameObject winningStuff;
    public Button exit;
    public Text green;
    public Text blue;
    public bool greenWon = false;
    public GameObject pauseStuff;
    public GameObject counter;
    public bool hasGameEnded = false;
    private TeamHealth teamHealth;

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
        if (_totalHp<= 0)
        {
            pauseStuff.gameObject.SetActive(false);
            counter.gameObject.SetActive(false);
            Time.timeScale = 0.0f;
            winningStuff.gameObject.SetActive(true);
            
            green.gameObject.SetActive(teamColor=="Blue");
            blue.gameObject.SetActive(teamColor=="Green");
            

            hasGameEnded = false;

            exit.onClick.AddListener(BackToMenu);
        }
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

    void BackToMenu()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1.0f;
    }

}
