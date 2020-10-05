using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float bulletSpeed, damage, timer;

    public GameObject target;
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

    void OnCollision2D(Collision2D col)
    {
        if (col == null) { return; }
        GameObject obj = col.gameObject;


        if (obj.GetComponent<Movement>() != null) //check to see if I collided with player
        {
            obj.GetComponent<Movement>().timer -= damage;
        }
        if (obj.CompareTag("Floor")) { return; }
        Destroy(gameObject);
    }
    public void SetSpeed(float speed, float bulletDamage, float bulletTimer)
    {
        bulletSpeed = speed;
        damage = bulletDamage;
        timer = bulletTimer;


    }
    
}
