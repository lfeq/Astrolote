using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private float raycastDistance = 5f;
    [SerializeField] private Transform carryObjectPosition;
    [SerializeField] private LayerMask grabableLayerMasks;
    private bool isCarrying;
    private Transform carryedObject;

    private void OnInteract(InputValue value)
    {
        if (value.isPressed)
            Grab();
    }

    private void Grab()
    {
        if(!isCarrying)
        {
            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.right, raycastDistance, grabableLayerMasks);

            if(hit.collider.GetComponent<Grabable>() != null)
            {
                hit.collider.transform.SetParent(transform);
                carryedObject = hit.collider.transform;
                carryedObject.position = carryObjectPosition.position;
                isCarrying = true;
            }
        }

        else if(isCarrying)
        {
            carryedObject.SetParent(null);
            carryedObject = null;
            isCarrying = false;
        }
    }
}
