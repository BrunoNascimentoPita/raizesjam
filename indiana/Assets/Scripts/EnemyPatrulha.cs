using UnityEngine;

public class EnemyPatrulha : MonoBehaviour
{
    private Rigidbody2D rb;
    // Patrulha
    public float patrolTime;
    public float patrolSpeed;

    // Perseguição
    public float chaseSpeed;

    public float timer;
    public float detectionRange;

    public float direction = 1;

    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0f;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if(playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            Vector2 chaseDirection = (player.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(chaseDirection.x * chaseSpeed, rb.linearVelocity.y);
        }
        else
        {
            timer += Time.deltaTime;
            if(timer >= patrolTime)
            {
                direction *= - 1;
                timer = 0f;
            }
            rb.linearVelocity = new Vector2(direction * patrolSpeed, rb.linearVelocity.y);
        }
    }
}
