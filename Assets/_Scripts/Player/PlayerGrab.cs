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
    [SerializeField] private GameObject promptGameObject;
    private bool isCarrying;
    private Transform carryedObject;
    private RaycastHit2D hit;

    private void Start()
    {
        HidePrompt();
    }

    private void Update()
    {
        if (IsGrabable())
            ShowPrompt();
        else
            HidePrompt();
    }

    private void OnInteract(InputValue value)
    {
        if (value.isPressed)
            Grab();
    }

    private bool IsGrabable()
    {
        hit = Physics2D.Raycast(raycastOrigin.position, Vector2.right, raycastDistance, grabableLayerMasks);

        if(hit.collider != null)
        {
            if (hit.collider.GetComponent<Grabable>() != null)
                return true;
        }
        return false;

    }

    private void Grab()
    {
        if(!isCarrying)
        {
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

    private void ShowPrompt()
    {
        promptGameObject.SetActive(true);
    }

    private void HidePrompt()
    {
        promptGameObject.SetActive(false);
    }
}
