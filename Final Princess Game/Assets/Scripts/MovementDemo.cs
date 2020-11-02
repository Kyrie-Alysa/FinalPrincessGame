using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MovementDemo : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 moveDir;
    public float charSpeed = 8f;
    public Animator animator;
    private bool isDashButtonDown;

    private void Awake(){rb = GetComponent<Rigidbody2D>();}

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)){
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S)){
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A)){
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D)){
            moveX = 1f;
        }
        moveDir = new Vector3(moveX, moveY).normalized;
        animator.SetFloat("Horizontal", moveDir.x);
        animator.SetFloat("Vertical", moveDir.y);
        animator.SetFloat("Speed", moveDir.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashButtonDown = true;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = moveDir * charSpeed;
        if (isDashButtonDown){
            float dashAmount = 6f;
            Vector3 dashPosition = transform.position + moveDir * dashAmount;
            RaycastHit2D ray = Physics2D.Raycast(transform.position, moveDir, dashAmount);
            if (ray.collider != null)
            {
                dashPosition = ray.point;
            }
            rb.MovePosition(transform.position + moveDir * dashAmount);
            isDashButtonDown = false;
        }
    }
}
