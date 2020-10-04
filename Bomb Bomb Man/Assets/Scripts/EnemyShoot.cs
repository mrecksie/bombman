using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour, IExplode
{

    #region | Bullet Stats
    public float bulletSpeed, bulletDamage, timeOfBullet;
    #endregion | Bullet Stats

    public GameObject projectile;

    public GameObject target;
    Vector2 targetPos;

    public float waitTime; //time enemy waits between shots
    float currentTime; //how close we are to the next shot

    public float turnSpeed, attackRadius;

    

    void Start()
    {
        currentTime = 3; //initialize
        target = FindObjectOfType<Movement>().gameObject;
        attackRadius = 3f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        targetPos = (Vector2)target.transform.position;

        if ((targetPos - (Vector2)transform.position).magnitude >= attackRadius) { return; }
        RaycastHit2D enemyScan = Physics2D.Raycast((Vector2)transform.position, targetPos - (Vector2)transform.position, LayerMask.GetMask("Ignore Raycast", "UI", "Floor")); //Sends a ray towards the playerW
        if (enemyScan.collider == null) { return; }
        if (!enemyScan.collider.CompareTag("Player")) { return; }
        FacePlayer();
        if (currentTime >= waitTime)
        {
            Fire(targetPos); //Decided to "respawn" the player by setting their position to the spawn point, rather than create a new instance
            currentTime = 0;
        }
    }

    void Fire(Vector2 pos)
    {
        Vector3 spawnHere = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        ProjectileMovement obj = Instantiate(projectile, spawnHere, gameObject.transform.rotation).GetComponent<ProjectileMovement>();
        obj.SetSpeed(bulletSpeed, bulletDamage, timeOfBullet);
        obj.gameObject.SetActive(true);
    }

    void FacePlayer()
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turnSpeed);
    }


    //When player explodes this will trigger
    // IGNORE explosionLocation, only used for destroying tiles on a tilemap
    public void OnExplode(Vector2 explosionLocation)
    {
        //Anything that happens before the object is deleted like death animation
        Destroy(this);
    }
}
