using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    [SerializeField] public float moveSpeed, jumpHeight;
    [SerializeField] private Vector2 movement;
    [SerializeField] private float moveHorizontal;
    //	[SerializeField]public TeamHealth teamHealth;
    public GameObject p1;
    private Rigidbody2D player;
    private Vector3 m_Velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        p1 = GameObject.FindGameObjectWithTag("Player");
        player = p1.GetComponent<Rigidbody2D>();
        //		teamHealth.setSize(0.4f);

    }

    void Update()
    {
        //       moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        //       moveHorizontalP2 = Input.GetAxis("HorizontalP2") * moveSpeed;




    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (player.transform.position.y < 1.5)
            {
                player.AddForce(new Vector2(0f, jumpHeight));
            }
        }

        //       Vector3 targetVelocity = new Vector2(moveHorizontal*Time.fixedDeltaTime * 10f, player.velocity.y);
        //       player.velocity = Vector3.SmoothDamp(player.velocity, targetVelocity, ref m_Velocity, 0.05f);

        Vector3 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime * 10f, player.velocity.y);
        player.velocity = Vector3.SmoothDamp(player.velocity, targetVelocity, ref m_Velocity, 0.05f);
    }
}
