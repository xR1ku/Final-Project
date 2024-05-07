using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Bounce")){
            float bounceForce = 10.0f;
            GameObject myObject = other.gameObject;
            Rigidbody2D rb2D = myObject.GetComponent<Rigidbody2D>();
            rb2D.AddForce(rb2D.transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}
