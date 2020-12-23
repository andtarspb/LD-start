using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    [SerializeField]
    Door door;

    [SerializeField]
    bool frontCollider;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (frontCollider)
            {
                door.currentPlayerPos = Door.PlayerPos.Front;
            }
            else
            {
                door.currentPlayerPos = Door.PlayerPos.Back;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door.currentPlayerPos = Door.PlayerPos.Far;
        }
    }

}
