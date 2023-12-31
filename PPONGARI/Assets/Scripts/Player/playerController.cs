using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        playerMovement.Move();

        if (Input.GetButtonDown("Jump"))
        {
            playerMovement.Jump();
        }

        if (Input.GetButton("Jump"))
        {
            playerMovement.isLongJump = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            playerMovement.isLongJump = false;
        }

        if (Input.GetButtonDown("PositionReset"))
        {
            playerMovement.PositionReset();
        }
    }
}