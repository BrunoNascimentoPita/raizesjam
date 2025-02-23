using UnityEngine;

public class EnemyPatrulha : MonoBehaviour
{
    private Rigidbody2D rb;

    public int danoParaDar;
    private SpriteRenderer spriteRenderer;
    private Animator animatorTatu;

    // Patrulha
    public float patrolTime;
    public float patrolSpeed;

    // Perseguição
    public float chaseSpeed;
    public float detectionRange;

    private float timer;
    private float direction = 1;

    private Transform player;

    // Novo temporizador para preparação antes de rolar
    private float prepareTime = 0.5f; 
    private float prepareTimer = 0f;
    private bool isPreparing = false;
    private bool isChasing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Pegando o SpriteRenderer
        animatorTatu = GetComponent<Animator>();

        timer = 0f;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) < detectionRange)
        {
            // Se ainda não estiver se preparando nem perseguindo
            if (!isPreparing && !isChasing)
            {
                isPreparing = true;
                prepareTimer = 0f;
                animatorTatu.Play("preparandopararolartatu");
            }

            // Contagem do tempo de preparação
            if (isPreparing)
            {
                prepareTimer += Time.deltaTime;

                if (prepareTimer >= prepareTime)
                {
                    isPreparing = false;
                    isChasing = true;
                    animatorTatu.Play("rolandoTatu");
                }
            }

            // Se já estiver perseguindo, move o inimigo
            if (isChasing)
            {
                Vector2 chaseDirection = (player.position - transform.position).normalized;
                rb.linearVelocity = new Vector2(chaseDirection.x * chaseSpeed, rb.linearVelocity.y);

                // Corrigido: Agora flipa corretamente na perseguição
                spriteRenderer.flipX = chaseDirection.x < 0;
            }
        }
        else
        {
            // Reseta estados caso o jogador saia do alcance
            isPreparing = false;
            isChasing = false;
            prepareTimer = 0f;

            timer += Time.deltaTime;
            if (timer >= patrolTime)
            {
                direction *= -1;
                timer = 0f;
                
                // Correção do flip durante a patrulha
                spriteRenderer.flipX = direction > 0;
            }

            animatorTatu.Play("patrulhandoTatu");
            rb.linearVelocity = new Vector2(direction * patrolSpeed, rb.linearVelocity.y);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerLife>().MachucarPlayer(danoParaDar);
        }
    }
}
