using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 5.0f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        Move(directionX);
    }

    void Move(float directionX)
    {
        if(directionX == 1)
        {
            spriteRenderer.flipX = false;
        }
        else if(directionX == -1)
        {
            spriteRenderer.flipX = true;
        }

        transform.Translate(directionX * speed * Time.deltaTime, 0, 0);
    }

}
