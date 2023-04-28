using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerChapGpt : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0f).normalized;

        if (movement != Vector2.zero)
        {
            animator.SetBool("isRunning", true);
            animator.SetFloat("Horizontal", movement.x);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
