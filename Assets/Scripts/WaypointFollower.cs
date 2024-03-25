using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // waypoint list
    private int currentWaypointIndex = 0; 

    [SerializeField] private float speed = 2f; // speed of the object, can be changed in the inspector

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) // if the object is close to the waypoint, move to the next waypoint
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) // if the object reaches the last waypoint, go back to the first waypoint
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); // move the object towards the current waypoint, time.deltaTime is used to make the movement frame rate independent
    }
}