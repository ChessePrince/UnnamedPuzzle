using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform playerPos;
    private Transform compTransform;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public float offset;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        RandomizeValues();
    }
    private void Update()
    {
        if (!PauseControl.gameIsPaused && !PauseControl.playerIsDead) 
        {
            Movement();
        }   
    }
    void Movement()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, playerPos.position) < stoppingDistance && Vector2.Distance(transform.position, playerPos.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, playerPos.position) > retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -speed * Time.deltaTime);
        }
        LookAtPlayer();
    }
    void LookAtPlayer()
    {
        Vector3 difference = playerPos.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
    void RandomizeValues()
    {
        speed = Random.Range(speed - 5, speed + 1);
        retreatDistance = Random.Range(retreatDistance - 1, retreatDistance + 1);
        stoppingDistance = Random.Range(stoppingDistance - 1, stoppingDistance + 1);
    }
}
