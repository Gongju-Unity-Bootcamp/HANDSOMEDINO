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

    [SerializeField]
    Transform startPoint;
    Transform playerTransform;
    public Vector2 lastCheckPointPos;

    [SerializeField]
    Transform wallCheck;
    [SerializeField]
    private float wallCheckDistance;
    [SerializeField]
    private float slidingSpeed;
    [SerializeField]
    private LayerMask wallLayer;
    private bool isWall;
    private float directionX; 
    

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        playerTransform = GetComponent<Transform>();
        startPoint = GetComponent<Transform>();

        lastCheckPointPos = new Vector2(startPoint.position.x, startPoint.position.y);
    }

    void FixedUpdate()
    {
        Bounds bounds = circleCollider2D.bounds;
        directionX = Input.GetAxisRaw("Horizontal");
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        isGround = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);
        isWall = Physics2D.Raycast(wallCheck.position, Vector2.right * directionX, wallCheckDistance, wallLayer);

        WallJump();

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

    public void Move()
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

    public void PositionReset()
    {
        playerTransform.position = lastCheckPointPos;
    }

    public void WallJump()
    {
        if (isWall)
        {
            currentJumpCount = maxJumpCount;
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, rigid2D.velocity.y * slidingSpeed);
        }
    }
}
