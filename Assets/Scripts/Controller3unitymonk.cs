using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3unitymonk : MonoBehaviour
{
    Animator anim;
    public float speed = 10f;
    private Rigidbody2D _rigid;
    public float jumpForce = 150f;

    private bool isJump = false;
    private bool _direction = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float _moveInput = Input.GetAxis("Horizontal");
      

        _rigid.velocity = new Vector2(speed * _moveInput, _rigid.velocity.y);

        if (_direction == true && _moveInput < 0)
        {
            Flip();
        }
        else if (_direction == false && _moveInput > 0)
        {
            Flip();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if(isJump == false)
            {
                _rigid.AddForce(Vector2.up * jumpForce);
                isJump = true;
                anim.SetTrigger("jump");
            }
        }

        void Flip()
        {
            _direction = !_direction;
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            isJump = false;
            anim.SetBool("grounded", true);
        }

        if (collision.gameObject.CompareTag("Dead"))
        {
            Destroy(gameObject);
        }
           
    }
}
