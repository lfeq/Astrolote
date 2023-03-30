using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private LayerMask isInteractable;
    [SerializeField] private float raycastDistance = 5f;


    private void OnInteract(InputValue value)
    {
        if (value.isPressed)
        {
            Interact();
        }
    }

    private void Interact()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.right, raycastDistance, isInteractable);

        hit.collider?.GetComponent<IInteractable>().Interact(transform);
    }
}
