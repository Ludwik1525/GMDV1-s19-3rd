using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour {

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //a bool for determining whether the player is already in idle state or not
    public bool isIdle = false;

    //bool for determining whether the player is in the air or not
    public bool isGrounded;

    public bool facingRight = true;

    public string walk;
    public string idle;
    public string jump;

    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!facingRight)
            {
                Flip();
            }

            facingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (facingRight)
            {
                Flip();
            }

            facingRight = false;
        }

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                anim.Play(walk);
                isIdle = false;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.Play(walk);
                isIdle = false;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                anim.Play(jump);
                isIdle = false;
            }

            if (!Input.anyKey)
            {
                if (!isIdle)
                {
                    anim.Play(idle);
                }

                isIdle = true;
            }
        }
        else
        {
            anim.Play(idle);
        }


	}
    
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Enter ground");
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("Leave ground");
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
