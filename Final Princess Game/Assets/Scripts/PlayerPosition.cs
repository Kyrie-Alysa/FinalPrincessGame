using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    public GameObject gameObject;

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find(gameObject.name).transform.position;
        Debug.Log(gameObject.name + ": positition is now " + transform.position);
    }
}
