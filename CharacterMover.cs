using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Put this script to object you wanna control.
/// </summary>
public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float speed; // Speed of character.
    [SerializeField] private float jumpForce; // How hight cyou wanna jump?
    [SerializeField] private Transform groundCheck; // Is character on the ground. You can put here a character or child empty object.
    [SerializeField] private float groundRadius; // Radius for check of ground
    [SerializeField] private LayerMask whatIsGround; // Layer of object which is ground.
    private bool facingRight = false; // Flag for switch a view direction.
    private bool grounded = false; // Flag for prevent a multiple-jump.
    private Rigidbody2D rb; // Character must have rigidbody!

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        float move = Input.GetAxis("Horizontal");
        MoveCharacter(move);
    }

    private void Update()
    {
        if (grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Jump();
        }
    }

    private void MoveCharacter(float move)
    {
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce));
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}