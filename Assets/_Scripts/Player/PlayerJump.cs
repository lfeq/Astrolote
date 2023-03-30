using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8;
    private Rigidbody2D rigidBody;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            Jump();
        }

        if (!value.isPressed)
        {

        }
    }
}
