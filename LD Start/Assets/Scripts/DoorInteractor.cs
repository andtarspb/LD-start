using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorInteractor : MonoBehaviour
{
    [SerializeField]
    string doorTag = "door";

    [SerializeField]
    float rayLength;

    [SerializeField]
    GameObject openDoortext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        openDoortext.SetActive(false);


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            var door = hit.transform;
            if (door.CompareTag(doorTag))                
            {
                openDoortext.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (door.GetComponent<DoorWithLatch>())
                    {
                        door.GetComponent<DoorWithLatch>().Interact();
                    }
                    else
                    {
                        door.GetComponent<Door>().Interact();
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<DoorCollider>())
        {
            openDoortext.GetComponent<Text>().text = "Press \"E\" to interact with the door";

            var col = other.GetComponent<DoorCollider>();
            if (col.GetComponentInParent<DoorWithLatch>())
            {
                var doorWithLatch = col.GetComponentInParent<DoorWithLatch>();
                if (col.frontCollider && doorWithLatch.locked && doorWithLatch.triedToOpen)
                {
                    openDoortext.GetComponent<Text>().text = "Locked from the other side";
                }
            }
            
        }
    }
}
