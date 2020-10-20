using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovementDemo : MonoBehaviour
{
    public float movementSpeed = 8f;
    public Animator animator;
    public Rigidbody2D rb;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // FixedUpdate isn't dependent on the framerate, so it updates at a constant rate
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
