using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float speed = 8.5f;

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if(Vector3.Distance(transform.position, target.position) > 1f)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }
}
