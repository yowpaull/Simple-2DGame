using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerJump : MonoBehaviour
{
    public float moveSpeed;
    float xInput; 

    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator anim;

    public float jumpForce;
    bool isGrounded;


    public Transform groundCheck;
    public LayerMask groundlayer;
    public GameOverManager gameOverManager;
    private AudioSource sfxSource;
    public AudioClip jumpSound;
    public AudioClip gameOverSound;

    private string RUN_ANIMATION = "Run";
    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        sfxSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                Jump();

                sfxSource.PlayOneShot(jumpSound);
            }
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        PlatformerMove();
        FlipPlayer();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void PlatformerMove()
    {
        rb.velocity = new Vector2(moveSpeed * xInput, rb.velocity.y);
    }

    void FlipPlayer()
    {
        if (rb.velocity.x < -0.1f)
        {
            sp.flipX = true;
            anim.SetBool(RUN_ANIMATION, true);
        }
        else if (rb.velocity.x > 0.1f)
        {
            sp.flipX = false;
            anim.SetBool(RUN_ANIMATION, true);
        }
        else
        {
            anim.SetBool(RUN_ANIMATION, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            if (gameOverSound != null) sfxSource.PlayOneShot(gameOverSound);

            gameOverManager.ShowGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            if (gameOverSound != null)
            {
                AudioSource.PlayClipAtPoint(gameOverSound, transform.position);
            }

            gameOverManager.ShowGameOver();
            gameObject.SetActive(false); 
        }
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
        }
    }
}