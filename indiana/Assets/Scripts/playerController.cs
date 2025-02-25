using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInputHorizontal;
    private float moveInputVertical;
    public float speed = 5f;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isFacingRight = true;
    public float climbSpeed = 4f;
    private bool isClimbing = false;
    private float normalGravity;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
        animator = GetComponent<Animator>();
        Time.timeScale = 1f;
        animator.Play("PlayerIdle");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        moveInputHorizontal = Input.GetAxisRaw("Horizontal");
        moveInputVertical = Input.GetAxisRaw("Vertical");

        Movement();
        Jump();

        if (isClimbing)
        {
            Escalada();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                isClimbing = false;
                rb.gravityScale = normalGravity;
                JumpInClimbing();
            }
        }
    }

    void Movement()
{
    rb.linearVelocity = new Vector2(moveInputHorizontal * speed, rb.linearVelocity.y);

    if ((moveInputHorizontal > 0 && !isFacingRight) || (moveInputHorizontal < 0 && isFacingRight))
    {
        Flip();
    }

    if (isGrounded && !isClimbing)
    {
        animator.Play(moveInputHorizontal == 0 ? "PlayerIdle" : "PlayerRun");
    }
    else if (!isGrounded && !isClimbing)
    {
        animator.Play("PlayerJump");
    }
}


    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            animator.Play("PlayerJump");
        }
    }

   void JumpInClimbing()
{
    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

    // Somente desativa a escalada se não estiver mais tocando a superfície escalável
    if (!IsTouchingClimbable())
    {
        isClimbing = false;
        rb.gravityScale = normalGravity;
    }

    animator.Play("PlayerJump");
}
bool IsTouchingClimbable()
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, checkRadius);
    foreach (Collider2D collider in colliders)
    {
        if (collider.CompareTag("climbable"))
        {
            return true;
        }
    }
    return false;
}
    void Escalada()
    {
        rb.gravityScale = 0f;
        
        rb.linearVelocity = new Vector2(moveInputHorizontal * speed, moveInputVertical * climbSpeed);
        animator.Play("PlayerClimbingDeLado");

        if (moveInputVertical == 0)
        {
            
            rb.linearVelocity = new Vector2(moveInputHorizontal * speed, -2f);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

   void OnCollisionStay2D(Collision2D collision)
{
    if (collision.collider.CompareTag("climbable"))
    {
        isClimbing = true;
    }
    if (collision.collider.CompareTag("morte"))
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}   

 void OnCollisionExit2D(Collision2D collision)
{
    if (collision.collider.CompareTag("climbable"))
    {
        isClimbing = false;
        rb.gravityScale = normalGravity;
        animator.Play("PlayerIdle");
    }
}
}
