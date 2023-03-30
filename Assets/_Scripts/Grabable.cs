using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabable : MonoBehaviour, IInteractable
{
    public void Interact(Transform parent)
    {
        if (transform.parent == parent)
        {
            transform.parent = null;
        }

        else
        {
           transform.parent = parent;
        }
    }

    public void Interact()
    {

    }
}
