using UnityEngine;
using UnityEngine.SceneManagement;
public class playerController : MonoBehaviour
{
    private Rigidbody2D rb;
    // Movimentação
    private float moveInputHorizontal;
    private float moveInputVertical;
    public float speed = 5f;
    // Pulo
    public float jumpForce;
    private bool isGrounded;

        // Checar se está tocando no chão

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    // personagem mudar de lado
    private bool isFacingRight = true;

    // Personagem escalar
    public float climbSpeed = 4f;
    private bool isClimbing = false;
    private float normalGravity;
 private bool isPaused = false;
 public GameObject pauseMenu;
    // Controlar animação
    private Animator animator;

  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale; // guarda o valor original da gravidade
        animator = GetComponent<Animator>();
        
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsClimbingLado", false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            
        }
        moveInputHorizontal = Input.GetAxisRaw("Horizontal");
        moveInputVertical = Input.GetAxisRaw("Vertical");

        Movement();
        Jump();

        if (isClimbing == true)
        {
            Escalada();

            if(Input.GetKeyDown(KeyCode.Space))
            {
                isClimbing = false;
                rb.gravityScale = normalGravity;
                JumpInClimbing();
            }
        }
        
    }
public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
          if (pauseMenu != null)
        {
            pauseMenu.SetActive(isPaused);
        }
    }
    // Update is called once per frame
    void Movement()
    {
        
        rb.linearVelocity = new Vector2(moveInputHorizontal * speed, rb.linearVelocity.y);
        
        if (moveInputHorizontal > 0 && !isFacingRight) // Se mover para a direita e o personagem está virado para a esquerda
        {
            Flip();
            
        }
        else if (moveInputHorizontal < 0 && isFacingRight) // Se mover para a esquerda e o personagem está virado para a direita
        {
            Flip();
        }

        if(moveInputHorizontal == 0 && isGrounded == true)
        {
            animator.SetBool("IsIdle", true);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsClimbingLado", false);
        }

        else if(moveInputHorizontal != 0 && isGrounded == true)
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsClimbingLado", false);
        }

        else if(moveInputHorizontal != 0 && isGrounded == false)
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsClimbingLado", false);
        }
       
    }
    void Jump()
    {
        // verifica se o personagem está no chão usando o circulo de checagem e retorna um bool
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        
        
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsClimbingLado", false);
        }
    }

    void JumpInClimbing()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        animator.SetBool("IsIdle", false);
        animator.SetBool("IsJumping", true);
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsClimbingLado", false);
    }

    void Escalada()
    {
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(moveInputHorizontal * speed, moveInputVertical * climbSpeed);
        
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsClimbingLado", true);

        if(moveInputVertical == 0)
        {
            rb.linearVelocity = new Vector2(moveInputHorizontal * speed, -2f);
        }
        
    }

    void Flip()
    {
        isFacingRight = !isFacingRight; // Inverte o valor de isFacingRight

        // Inverte a escala no eixo X para flipar o personagem
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    // Detecta entrada em áreas escaláveis (objetos com tag "climbable")
    void OnCollisionEnter2D(Collision2D collision)
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

    // Detecta saída das áreas escaláveis
   void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("climbable"))
        {
            isClimbing = false;
            rb.gravityScale = normalGravity;

            animator.SetBool("IsClimbingLado", false);
            
        }
    }

}