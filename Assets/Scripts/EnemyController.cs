
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform waypoint1;
    [SerializeField]
    private Transform waypoint2;
    private Transform currentWaypoint;
    [SerializeField]
    private float moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoint1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(currentWaypoint.position, transform.position) > Mathf.Epsilon) {
            Move();
        } else {
            SwitchWaypoint();
        }
    }

    private void Move() {
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = currentWaypoint.position;

        Vector2 nextPosition = Vector2.MoveTowards(currentPosition, targetPosition,
        moveSpeed * Time.deltaTime);

        transform.Translate(nextPosition - currentPosition);
    }

    private void SwitchWaypoint() {
        if (currentWaypoint == waypoint1) {
            currentWaypoint = waypoint2;
        } else {
            currentWaypoint = waypoint1;
        }
    }
}
