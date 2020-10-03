using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed, timer;
    public Vector2 movement;

    Rigidbody2D rb;
    float ms;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        Debug.Log("I have gone boom");
    }
}

