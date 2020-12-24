using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    [SerializeField]
    Door door;

    [SerializeField]
    public bool frontCollider;

    //[SerializeField] GameObject buttonUI;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //buttonUI.SetActive(true);

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
            //buttonUI.SetActive(false);
            door.currentPlayerPos = Door.PlayerPos.Far;
        }
    }

}
