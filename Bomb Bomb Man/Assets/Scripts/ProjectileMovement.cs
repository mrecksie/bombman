using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float bulletSpeed, damage, timer;

    public GameObject target;
    float bulletTime;

    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
        float bs = bulletSpeed * Time.fixedDeltaTime;

        transform.Translate(new Vector3(0, bs, 0), Space.Self);
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject obj = col.gameObject;

        if (obj.GetComponent<EnemyShoot>())
        {
            return;
        }
        else if (obj.GetComponent<Movement>()) //check to see if I collided with player
        {
            obj.GetComponent<Movement>().playerTime -= damage;
        }


        Destroy(gameObject);
    }
    public void SetSpeed(float speed, float bulletDamage, float bulletTimer)
    {
        bulletSpeed = speed;
        damage = bulletDamage;
        timer = bulletTimer;

        
    }
}
