using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour
{
    PlayerMovement playerMovement;
    
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        transform.position = playerMovement.lastCheckPointPos;
    }
}
