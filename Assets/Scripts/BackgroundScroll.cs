using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float xSpeed, ySpeed;

    // Update is called once per frame
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(xSpeed, ySpeed) * Time.deltaTime, img.uvRect.size);
    }
}
