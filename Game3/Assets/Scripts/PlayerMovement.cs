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
    public Transform groundCheck;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
                player.AddForce(new Vector2(0f, jumpHeight));
                isGrounded = false;
        }

        Vector3 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime * 10f,
            player.velocity.y);
        player.velocity = Vector3.SmoothDamp(player.velocity, targetVelocity, ref m_Velocity, 0.05f);
    }
}
