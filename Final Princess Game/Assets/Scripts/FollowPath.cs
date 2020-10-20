using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    //arraw of waypoints to walk from one to the next one
    [SerializeField]
    Transform[] waypoint;

    //Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 3f;

    //Indext of current waypoint from which enemy walks to the next one
    int waypointIndex = 0;
    void Start()
    {
        //set position of enemy as position of the first waypoint
        transform.position = waypoint[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    //method to make the enemy walk
    void Move()
    {
        //Move towards the next waypoint
        transform.position = Vector2.MoveTowards(transform.position,
                                                 waypoint[waypointIndex].transform.position,
                                                 moveSpeed * Time.deltaTime);
        if(transform.position == waypoint[waypointIndex].transform.position)
        {
            //This method is never entered so it doesn't register that the current position is the position of the waypoint....
            //If the position of the waypoint has been reached, increase the index
            waypointIndex += 1;
            Debug.Log("Hello");
        }
        if(waypointIndex == waypoint.Length)
        {
            waypointIndex = 0;
        }
        Debug.Log("The amount of waypoints is: " + waypoint.Length);
    }
}
