using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 8f;

    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;

    Rigidbody2D rb;
    Animator anim;

    bool isGrounded;
    bool isDead;

    float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckGround();
        UpdateAnimator();
    }

    void FixedUpdate()
    {
        if (isDead) return;

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );
    }

    void UpdateAnimator()
    {
        anim.SetFloat("Speed", Mathf.Abs(moveInput));
        anim.SetBool("IsGrounded", isGrounded);
    }

    public void MoveLeft()
    {
        moveInput = -1;
        transform.localScale = new Vector3(-1,1,1);
    }

    public void MoveRight()
    {
        moveInput = 1;
        transform.localScale = new Vector3(1,1,1);
    }

    public void StopMove()
    {
        moveInput = 0;
    }

    public void Jump()
    {
        if (!isGrounded) return;

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void Sit(bool value)
    {
        anim.SetBool("IsSit", value);
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;

        anim.SetBool("IsDead", true);

        rb.velocity = new Vector2(-4f, 6f);
    }
}