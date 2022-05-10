using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for controlling the enemy's movement, which moves between two waypoints
 */
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform waypoint1;
    [SerializeField]
    private Transform waypoint2;
    private Transform targetWaypoint;
    private int targetIndex;

    [SerializeField]
    private float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        targetWaypoint = waypoint1;
        targetIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(targetWaypoint.position, transform.position) > Mathf.Epsilon)
        {
            Move();
        } 
        else //switch directions
        {
            SwitchPositions();
        }

    }

    /*
     * Move towards target position
     */
    private void Move()
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = targetWaypoint.position;
        //position enemy will be at after the move
        //move towards target position at movement speed multiplied by the amount of time that has past since last move
        Vector2 nextPosition = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        //apply movement we calculated to the enemy
        transform.Translate(nextPosition - currentPosition);
    }

    private void SwitchPositions()
    {
        //if moving towards waypoint 1, switch to go towards waypoint 2
        if (targetIndex == 1) 
        {
            targetWaypoint = waypoint2;
            targetIndex = 2;
        }
        else //if moving towards waypoint 2, switch to go towards waypoint 1
        {
            targetWaypoint = waypoint1;
            targetIndex = 1;
        }
    }

    /*
     * Makes enemy die, do anything you want to get done beforedeath happen in here
     */
    public void Die()
    {
        Debug.Log(name + " is dying");
        Destroy(gameObject);
    }
}
