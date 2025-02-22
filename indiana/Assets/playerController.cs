using UnityEngine;

public class playerController : MonoBehaviour
{
    public float jumpForce, speed = 5f;
    private Rigidbody2D rb;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
    Movement();
    Jump();
    }
    // Update is called once per frame
    void Movement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

       
    }
    void Jump()
    {
       
        if (Input.GetKeyDown(KeyCode.Space)){
rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
  
}
