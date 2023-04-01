using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundButton : MonoBehaviour
{
    [SerializeField] private LayerMask canInteractWithButtonLayerMask;
    [SerializeField] private UnityEvent OnActivateButton;
    [SerializeField] private UnityEvent OnDeactivateButton;
    private bool isActive;

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (((1 << other.gameObject.layer) & canInteractWithButtonLayerMask) != 0)
        {
            OnActivateButton.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & canInteractWithButtonLayerMask) != 0)
        {
            OnDeactivateButton.Invoke();
        }
    }
}
