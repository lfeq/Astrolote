using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Vector2 inputVector;
    private Rigidbody2D rigidBody;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rigidBody.velocity = new Vector2(inputVector.x, rigidBody.velocity.y);
    }

    private void OnMove(InputValue value)
    {
        float direction = value.Get<Vector2>().x;

        inputVector = new Vector2(direction * speed, rigidBody.velocity.y);
    }
}
