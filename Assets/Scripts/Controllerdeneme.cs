using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public int speed;
    public float jumpForce;
    float horizontal;
    bool karakterSagY�z = true;

    bool grounded;
    public Transform groundedControl;
    public float yaricapKontrol;
    public LayerMask zeminNe;

    int extraJump;
    int extraJumpSay�s�;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (grounded == true)
        {
            extraJump = extraJumpSay�s�;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && grounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        
    }


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundedControl.position, yaricapKontrol, zeminNe);
        horizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (karakterSagY�z == false && horizontal > 0)
        {
            Flip();
        }
        else if (karakterSagY�z == true && horizontal < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        karakterSagY�z = !karakterSagY�z;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    
}
