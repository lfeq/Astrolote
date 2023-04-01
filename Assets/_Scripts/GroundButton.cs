using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundButton : MonoBehaviour
{
    [SerializeField] private LayerMask canInteractWithButtonLayerMask;
    [SerializeField] private UnityEvent OnActivateButton;
    [SerializeField] private UnityEvent OnDeactivateButton;
    [SerializeField] private bool isActive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (((1 << other.gameObject.layer) & canInteractWithButtonLayerMask) != 0)
        {
            OnActivateButton.Invoke();
        }
    }
}
