using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWalk : MonoBehaviour
{
    public int coins;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float minY = -10f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (transform.position.y < minY) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        SetAnimation(moveInput);

        // =====================================================
        // FLIP SPRITE BERDASARKAN ARAH GERAK
        // =====================================================
        // Jika player bergerak ke kanan (moveInput > 0)
        if (moveInput > 0)
        {
            // Sprite menghadap kanan (normal)
            spriteRenderer.flipX = false;
        }
        // Jika player bergerak ke kiri (moveInput < 0)  
        else if (moveInput < 0)
        {
            // Sprite dibalik (menghadap kiri)
            spriteRenderer.flipX = true;
        }
        // Jika moveInput = 0, sprite tetap pada orientasi terakhir
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            if (moveInput == 0)
            {
                animator.Play("Player_Idle");
            }
            else
            {
                animator.Play("Player_Run");
            }
        }
        else
        {
            if (rb.linearVelocity.y > 0)
            {
                animator.Play("Player_Jump");
            }
            else
            {
                animator.Play("Player_Fall");
            }
        }
    }
}