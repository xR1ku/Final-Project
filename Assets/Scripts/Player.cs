using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Serialized Variables
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce;
    [SerializeField] float movSpeed;
    [SerializeField] Animator animator;
    [SerializeField] UnityEvent OnDeath;
    [NonSerialized] public AudioManager audioManager;
    
    //Private Variables
    bool onGround = true;
    Vector2 movDirection;

    private void OnDisable()
    {
        //Go to Game Over screen
        OnDeath.Invoke();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movDirection = new Vector2(0, 0);
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>(); //S.S
    }

    // Update is called once per frame
    void Update()
    {
        if(audioManager == null){ //S.S
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>(); //S.S
        }

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

    //Physics based updates (like our characters movement events)
    void FixedUpdate()
    {
        rb.AddForce(movDirection);
    }

    //Event called when a directional input is done by the player
    public void OnMovement(InputValue value)
    {
        var v = value.Get<float>();
        movDirection.x = (v * movSpeed);
        //movDirection.y = rb.velocity.y;
    }

    //Event called when space bar or south button is pressed by player
    public void OnJump()
    {
        if ( onGround )
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            audioManager.playSFX(audioManager.jump); //S.S
        }
    }

    //Collision events for our player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            onGround = true;
            //animator.SetBool("OnGround", true);
        }

        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 8)
        {
            audioManager.playSFX(audioManager.death); //S.S
            gameObject.SetActive(false);
        }
    }

    //Collision exits for our player
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            onGround = false;
            //animator.SetBool("OnGround", false);
        }

    }
}
