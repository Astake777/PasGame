using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWalk : MonoBehaviour
{
    //Variable public

    public int coins;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float minY = -10f;     //Nilai minimum untuk kondisi dimana jika player jatuh terlalu rendah maka scene di load ulang

    // Variable private
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
        // Input horizontal menggunakan A-D atau Arrow kiri/kanan (nilai moveInput = -1 kiri / 1 kanan)
        float moveInput = Input.GetAxis("Horizontal");

        // Gerakkan player = moveInput dikalikan moveSpeed. misalnya 1 * 5 = 5
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Lompatan (hanya jika menyentuh tanah)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Restart scene jika player jatuh terlalu rendah
        if (transform.position.y < minY)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Atur animasi berdasarkan kondisi gerak
        SetAnimation(moveInput);

        // mengatur animasi yang dimainkan berdasarkan arah gerak
        // jika bergerak ke kanan (saat menekan tombol D atau panah kanan), tidak perlu di-flip
        // jika bergerak ke kiri (saat menekan tombol A atau panah kiri), di-flip secara horizontal
        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;   // Menghadap kanan
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;    // Menghadap kiri
        }
    }

    private void FixedUpdate()
    {
        // Cek apakah groundCheck menyentuh ground
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            // jika player di tanah maka animasi idle atau run dijalankan
            // jika kecepatan horizontal dari player = 0 maka animasi idle dijalankan
            if (moveInput == 0)
            {
                animator.Play("Player_Idle");
            }
            // atau animasi run dijalankan (ketika nilai kecepatan horizontal dari player tidak sama dengan 0)
            else
            {
                animator.Play("Player_Run");
            }
        }
        else
        {
            // jika player di udara maka animasi jump (ketika nilai kecepatan vertikal dari player lebih dari 0)
            if (rb.linearVelocity.y > 0)
            {
                animator.Play("Player_Jump");
            }
            // atau fall dijalankan (ketika nilai kecepatan vertikal dari player kurang dari 0)
            else
            {
                animator.Play("Player_Fall");
            }
        }
    }
}
