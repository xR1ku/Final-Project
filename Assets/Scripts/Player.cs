using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce;
    [SerializeField] float movSpeed;
    [SerializeField] Animator animator;

    //Private Variables
    bool onGround = true;
    Vector2 movDirection;
    

    private void OnEnable()
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movDirection = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if (!onGround)
        {
            animator.SetBool("OnGround", false);
        }
        else
        {
            animator.SetBool("OnGround", true);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movDirection);
        
    }

    public void OnMovement(InputValue value)
    {
        var v = value.Get<float>();
        movDirection.x = (v * movSpeed);
        movDirection.y = (rb.velocity.y);
    }

    public void OnJump()
    {
        if ( onGround )
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            onGround = true;
            //animator.SetBool("OnGround", true);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            onGround = false;
            //animator.SetBool("OnGround", false);
        }
    }
}
