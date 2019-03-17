using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] public float moveSpeed, jumpHeight, moveHorizontal;//,moveHorizontalP2;
	[SerializeField]private Vector2 movement;
//	[SerializeField]public TeamHealth teamHealth;
	public GameObject p1,p2;
	private Rigidbody2D player;
	public Rigidbody2D rgbd1,rgbd2;
    private Vector3 m_Velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
		p1 = GameObject.FindGameObjectWithTag("Player");
		p2 = GameObject.FindGameObjectWithTag("Player2");
		rgbd1 = p1.GetComponent<Rigidbody2D>();
		rgbd2 = p2.GetComponent<Rigidbody2D>();
		jumpHeight = 20;
//		teamHealth.setSize(0.4f);
		
	}

    void Update()
    {
 //       moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
 //       moveHorizontalP2 = Input.GetAxis("HorizontalP2") * moveSpeed;

        

  
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetButtonDown("Jump"))
        {
            if (rgbd1.transform.position.y < 1.5)
            {
                rgbd1.AddForce(new Vector2(0f, jumpHeight));
            }
        }
        else if (Input.GetButtonDown("JumpP2"))
        {
            if (rgbd2.transform.position.y < 1.5)
            {
                rgbd2.AddForce(new Vector2(0f, jumpHeight));
            }
        }

        //       Vector3 targetVelocity = new Vector2(moveHorizontal*Time.fixedDeltaTime * 10f, player.velocity.y);
        //       player.velocity = Vector3.SmoothDamp(player.velocity, targetVelocity, ref m_Velocity, 0.05f);

        Vector3 targetVelocity1 = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime * 10f, rgbd1.velocity.y);
            rgbd1.velocity = Vector3.SmoothDamp(rgbd1.velocity, targetVelocity1, ref m_Velocity, 0.05f);
 

           // Vector3 targetVelocity2 = new Vector2(Input.GetAxis("HorizontalP2") * moveSpeed * Time.fixedDeltaTime * 10f, rgbd2.velocity.y);
           // rgbd2.velocity = Vector3.SmoothDamp(rgbd2.velocity, targetVelocity2, ref m_Velocity, 0.05f);
    }

}
