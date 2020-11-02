using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private IDoor doorG;
    private float timer;

    public Transform player;

    private void Awake()
    {
        doorG = doorGameObject.GetComponent<IDoor>();
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                doorG.CloseDoor();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        doorG.OpenDoor();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer = .7f;
    }
}
