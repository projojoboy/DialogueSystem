using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    CharacterController2D controller;
    Animator anim;
    Rigidbody2D rb;

    [SerializeField] float runSpeed = 30f;

    float horizontalMove = 0f;
    bool jump = false;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJumping", true);
        }

        if(rb.velocity.y <= -0.01)
        {
            anim.SetBool("IsFalling", true);
            anim.SetBool("IsJumping", false);
        }
        else
        {
            anim.SetBool("IsFalling", false);
        }
	}

    public void OnLanding()
    {
        anim.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
