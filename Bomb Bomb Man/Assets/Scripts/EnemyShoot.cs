using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectile;

    public GameObject target;
    Vector2 targetPos;

    public float waitTime; //time enemy waits between shots
    float currentTime; //how close we are to the next shot

    public float turnSpeed;

    void Start()
    {
        currentTime = 0; //initialize
    }

    void Update()
    {

        targetPos = (Vector2)target.transform.position;
        FacePlayer();

        currentTime += Time.deltaTime;

        if(currentTime >= waitTime)
        {
            Fire(targetPos); //Decided to "respawn" the player by setting their position to the spawn point, rather than create a new instance
            currentTime = 0;
        }
    }

    void Fire(Vector2 pos)
    {
        Vector3 spawnHere = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
        GameObject obj = Instantiate(projectile, spawnHere, gameObject.transform.rotation);
        obj.SetActive(true);
    }

    void FacePlayer()
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turnSpeed);
    }
}
