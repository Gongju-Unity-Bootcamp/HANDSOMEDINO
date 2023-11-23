using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid2D;

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float jumpForce = 6.5f;
    [SerializeField]
    private float longJumpGravityScale = 1f;
    [SerializeField]
    private float shortJumpGravityScale = 2.5f;
    public bool isLongJump = false;

    [SerializeField]
    private LayerMask groundLayer;
    private CircleCollider2D circleCollider2D;
    private bool isGround;
    private Vector2 footPosition;

    [SerializeField]
    private int maxJumpCount = 2;
    private int currentJumpCount = 0;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Bounds bounds = circleCollider2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        isGround = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        if (isGround == true && rigid2D.velocity.y <= 0)
        {
            currentJumpCount = maxJumpCount;
        }

        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = longJumpGravityScale;
        }
        else
        {
            rigid2D.gravityScale = shortJumpGravityScale;
        }
    }

    public void Move(float directionX)
    {
        if(directionX == 1)
        {
            spriteRenderer.flipX = false;
        }
        else if(directionX == -1)
        {
            spriteRenderer.flipX = true;
        }

        rigid2D.velocity = new Vector2(directionX * speed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if (currentJumpCount > 0)
        {
            rigid2D.velocity = Vector2.up * jumpForce;
            currentJumpCount--;
        }
    }
}
