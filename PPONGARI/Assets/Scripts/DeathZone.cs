using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        playerMovement.PositionReset();
    }
}