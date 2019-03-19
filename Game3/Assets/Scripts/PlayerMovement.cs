using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed, jumpHeight;
    [SerializeField] private Vector2 movement;
    [SerializeField] private float moveHorizontal;

    private Rigidbody2D player;
    private Vector3 m_Velocity = Vector3.zero;
    public bool isGrounded=true;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
                player.AddForce(new Vector2(0f, jumpHeight));
        }

        Vector3 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime * 10f,
            player.velocity.y);
        player.velocity = Vector3.SmoothDamp(player.velocity, targetVelocity, ref m_Velocity, 0.05f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Enter ground");
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("Leave ground");
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Player")
        {
            isGrounded = false;
        }
    }
}
