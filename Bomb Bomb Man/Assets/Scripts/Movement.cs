using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed, playerTime;
    public Vector2 movement;

    public int bombsUsed;

    private int multiplier;

    Rigidbody2D rb;
    float ms;
    public float timer { get; set; }

    //Events for explode
    public delegate void Explosion();
    public Explosion OnExplosion;

    void Start()
    {
        bombsUsed = 0;
        rb = GetComponent<Rigidbody2D>();
        timer = playerTime;
        multiplier = 1;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            multiplier = 4;
        }
        else
        {
            multiplier = 1;
        }
        timer -= multiplier * Time.deltaTime;

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
        if (OnExplosion != null) { OnExplosion.Invoke(); }
        bombsUsed += 1;
        Respawn();

        //send player back to starting position
    }
    public void Respawn()
    {
        timer = playerTime;
        // Set location to start and also whatever else we need

        transform.position = Vector3.zero;
    }

    public void nextScene()
    {

    }
}

