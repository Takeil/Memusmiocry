using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool controllable = true;
    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0;
    bool jump = false;

    public float runSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        if (controllable)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", horizontalMove);

            // Jump
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("Jump", true);
            }
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        jump = false;
        animator.SetBool("Jump", false);
    }

    public void ToggleControl(bool enable)
    {
        controllable = enable;
        horizontalMove = 0;
        animator.SetFloat("Speed", horizontalMove);
    }
}
