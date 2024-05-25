﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    [Header("Score Text")]
    public Text scoreText;

    private float topScore = 0.0f;
    //Rigidbody2D object that is stored
    [Header("Rigidbody")]
    public Rigidbody2D rb;
    // downward speed of the object
    [Header("Default Down Speed")]
    public float downSpeed = 20f;
    //movement speed of the object
    public float movementSpeed = 10f;
    //movement direction of the object
    [Header("Default directional movement speed")]
    public float movement = 0f;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
movement = Input.GetAxis("Horizontal") * movementSpeed;
if (movement < 0)
{
    this.GetComponent<SpriteRenderer>().flipX = false;

}
else
{
    this.GetComponent<SpriteRenderer>().flipX = true;
}
    if (rb.velocity.y > 0 && transform.position.y > topScore)
    {
     topScore = transform.position.y;
    }
    scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        }
        void FixedUpdate()
        {
            Vector2 velocity = rb.velocity;
            velocity.x = movement;
            rb.velocity = velocity;
        }
private void OnCollisionEnter2D(Collision2D collision)
{
    rb.velocity = new Vector3(rb.velocity.x, downSpeed, 0);
}
}

