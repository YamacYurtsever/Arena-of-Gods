using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float diagonalSpeedMultiplier = 0.75f;

    private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        animator.SetFloat("speed", (Mathf.Abs(horizontal) + Mathf.Abs(vertical)));

        //if the player is moving diagonally limit movement speed
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= diagonalSpeedMultiplier;
            vertical *= diagonalSpeedMultiplier;
        }
    }
}
