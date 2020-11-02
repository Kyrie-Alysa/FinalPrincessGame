using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AllMovement : MonoBehaviour
{
    //setup for FoV
    public Transform player;
    public float maxAngle;
    public float maxRadius;

    public Vector3 linVel;
    private Vector3 prevPos = Vector3.zero;
    private Quaternion prevRot = Quaternion.identity;

    private bool isInFov = false;

    //speed for following
    public float speed = 8.5f;
    //setup for FollowPath
    [SerializeField]
    Transform[] waypoint;
    //Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 3f;
    //Indext of current waypoint from which enemy walks to the next one
    int waypointIndex = 0;

    void Start()
    {
        transform.position = waypoint[waypointIndex].transform.position;
    }

    //Draw Gizmos FoV
    private void OnDrawGizmos()
    {
        if (!isInFov)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, maxRadius);

            //quaternion is a rotation so when multiplying an angle with it you rotate the vector
            //transform.forward is the axis we revolve around
            Vector2 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.forward) * transform.up * maxRadius;
            Vector2 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.forward) * transform.up * maxRadius;

            //draw FOV angle
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, fovLine1);
            Gizmos.DrawRay(transform.position, fovLine2);

            //draw line to princess
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

            //draw looking direction
            Gizmos.color = Color.black;
            Gizmos.DrawRay(transform.position, transform.up * maxRadius);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, (player.position - transform.position));
        }
    }
    //Check if in FoV
    public static bool inFov(Transform checkingObject, Transform target, float maxRadius, float maxAngle)
    {
        //create an array for tracking overlaps with 10 elements
        Collider2D[] overlaps = new Collider2D[40];
        int count = Physics2D.OverlapCircleNonAlloc(checkingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count + 1; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform == target)
                {
                    //Debug.Log("Princess in radius");
                    Vector2 directionBetween = (target.position - checkingObject.position).normalized;
                    //directionBetween.z *= 0;

                    float angle = Vector2.Angle(checkingObject.up, directionBetween);

                    if (angle <= maxAngle)
                    {
                        //Debug.Log("And in the angle o my god");
                        RaycastHit2D hit = new RaycastHit2D();
                        //if (hit.transform == target) //here lies the problem
                        //{
                        //    return true;
                        //}
                        return true;
                    }
                }
            }
        }
        //Debug.Log("Do you really really really wanna go hard");
        return false;
    }

    //Move waypoints
    void Move()
    {
        //Move towards the next waypoint
        transform.position = Vector2.MoveTowards(transform.position,
                                                 waypoint[waypointIndex].transform.position,
                                                 moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, waypoint[waypointIndex].transform.position) < .01f)
        {
            waypointIndex += 1;
        }

        if (waypointIndex == waypoint.Length)
        {
            waypointIndex = 0;
        }
        if (linVel.x < 0) //left
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        if (linVel.y < 0) //down
        {
            transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        if (linVel.x > 0) //right
        {
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        if (linVel.y > 0) //up
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void MoveToPlayer()
    {
        transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
        transform.LookAt(player.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, player.position) > 1f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    // Update is called once per frame
    public void Update()
    {
        //update for FoV
        linVel = (transform.position - prevPos) / Time.deltaTime;
        Vector3 angularVel = (transform.rotation.eulerAngles - prevRot.eulerAngles) / Time.deltaTime;
        prevPos = transform.position;
        prevRot = transform.rotation;
        if (!isInFov)
        {
            isInFov = inFov(transform, player, maxRadius, maxAngle);
            if (!isInFov)
            {
                Move();
            }
            else
            {
                isInFov = true;
            }
        }
        if(isInFov)
        {
            MoveToPlayer();
        }
    }
}
