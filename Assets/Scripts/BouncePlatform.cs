using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void Update(){
        if(audioManager == null){ //S.S
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>(); //S.S
        }
    }
    

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Bounce")){
            float bounceForce = UnityEngine.Random.Range(6.0f, 11.0f);
            GameObject myObject = other.gameObject;
            Rigidbody2D rb2D = myObject.GetComponent<Rigidbody2D>();
            rb2D.AddForce(rb2D.transform.up * bounceForce, ForceMode2D.Impulse);
            audioManager.playSFX(audioManager.ballBounce[UnityEngine.Random.Range(0, audioManager.ballBounce.Length)]); //S.S
        }
    }
}
