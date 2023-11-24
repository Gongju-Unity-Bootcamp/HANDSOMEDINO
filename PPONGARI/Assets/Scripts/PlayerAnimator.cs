using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    PlayerMovement playerMovement;
    Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("isWalking", true);
        }
        else 
        { 
            animator.SetBool("isWalking", false); 
        }
    }

    public void Jump()
    {
        if (playerMovement.isLongJump && rigid2D.velocity.y > 0)
        {
            animator.SetBool("isJump", true);
            //Debug.Log("Jump");
        }
        else
        { 
            animator.SetBool("isJump", false); 
        }
    }

}
