using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    [SerializeField] private Transform closePosition;
    [SerializeField] private Transform openPosition;
    [SerializeField] private float speed;
    private bool isOpeningClosening = false;
    private Transform positionToMove;

    private void Update()
    {
        if (isOpeningClosening)
        {
            transform.position = Vector2.MoveTowards(transform.position, positionToMove.position, speed * Time.deltaTime);

            if(Vector2.Distance(transform.position, positionToMove.position) <= 0.1f)
                isOpeningClosening = false;
        }
    }

    public void CloseDoor()
    {
        isOpeningClosening = true;
        positionToMove = closePosition;
    }

    public void OpenDoor()
    {
        isOpeningClosening = true;
        positionToMove = openPosition;
    }
}
