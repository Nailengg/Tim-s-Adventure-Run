using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    private Animator animator;
    private bool isGrounded;
    private Rigidbody2D rb;

    private float moveInput;
    private bool jumpPressed;
    private bool isSitting;
    private BoxCollider2D boxCollider;
    private Vector2 standingSize;
    private Vector2 sittingSize;
    private Vector2 standingOffset;
    private Vector2 sittingOffset;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        boxCollider = GetComponent<BoxCollider2D>();
        standingSize = boxCollider.size;
        standingOffset = boxCollider.offset;

        sittingSize = new Vector2(standingSize.x, standingSize.y * 0.5f);
        sittingOffset = new Vector2(standingOffset.x, standingOffset.y - standingSize.y * 0.25f);
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        UpdateAnimation();
    }

    private void HandleMovement()
    {
        if (isSitting)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void HandleJump()
    {
        if(jumpPressed && isGrounded && !isSitting)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpPressed = false;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f;
        bool isJumping = !isGrounded;

        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isSitting", isSitting);
    }
    public void MoveLeftDown()
    {
        moveInput = -1;
    }

    public void MoveRightDown()
    {
        moveInput = 1;
    }

    public void StopMove()
    {
        moveInput = 0;
    }

    public void JumpButton()
    {
        jumpPressed = true;
    }

    public void SitDown()
    {
        isSitting = true;
        boxCollider.size = sittingSize;
        boxCollider.offset = sittingOffset;
    }

    public void StopSit()
    {
        isSitting = false;
        boxCollider.size = standingSize;
        boxCollider.offset = standingOffset;
    }
}