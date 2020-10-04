using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed, playerTime;
    public Vector2 movement;

    Rigidbody2D rb;
    float ms;
    public float timer { get; set; }
    

    void Start()
    {
        playerTime = 10f;
        rb = GetComponent<Rigidbody2D>();
        timer = playerTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Explode();
        }
    }

    void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        ms = moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement * ms);
    }

    void Explode()
    {
        //Debug.Log("I have gone boom");

        //destroy all nearby objects & play boom animation

        //send player back to starting position
    }
}

