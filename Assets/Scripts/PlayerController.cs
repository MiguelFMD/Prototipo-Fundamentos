using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private Vector2 moveInput;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Jump();
        Move();
        if (moveInput.x != 0)
        {
            sr.flipX = moveInput.x < 0;
        }

        anim.SetBool("IsMoving", Mathf.Abs(moveInput.x) > 0.1f);
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetBool("IsFalling", IsFalling());
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }
    private void Move()
    {
        float left = Keyboard.current.aKey.isPressed ? -1f : 0f;
        float right = Keyboard.current.dKey.isPressed ? 1f : 0f;
        moveInput = new Vector2(left + right, 0f);
    }

    private void Jump()
    {
        bool space = Keyboard.current.spaceKey.isPressed;
        if (space && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private bool IsFalling()
    {
        return rb.linearVelocity.y < -0.1f && !isGrounded;
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}