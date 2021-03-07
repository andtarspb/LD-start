using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    string doorTag = "door";
    [SerializeField]
    string keyTag = "key";
    [SerializeField]
    string weaponTag = "weapon";

    [SerializeField]
    float rayLength;

    [SerializeField]
    GameObject interactText;

    bool showedSwitchText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interactText.SetActive(false);


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

       
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            GameObject objectToInteract = hit.transform.gameObject;
            if (objectToInteract.CompareTag(doorTag))                
            {
                HandleDoorInteraction(objectToInteract);
            }
            else if (objectToInteract.CompareTag(keyTag))
            {
                HandleKeyInteraction(objectToInteract);
            }
            else if (objectToInteract.CompareTag(weaponTag))
            {
                HandleWeaponInteraction(objectToInteract);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<DoorCollider>())
        {
            HandleDoorText(other);
        }
    }

    void HandleKeyInteraction(GameObject obj)
    { 
        KeyScript key = obj.GetComponent<KeyScript>();

        interactText.GetComponent<Text>().text = "Press \"E\" to take \"" + key.keyName + "\"";
        interactText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            key.PickUpKey();
        }
    }

    void HandleWeaponInteraction(GameObject obj)
    {
        PickUpWeapon weapon = obj.GetComponent<PickUpWeapon>();

        interactText.GetComponent<Text>().text = "Press \"E\" to take \"" + weapon.weaponName + "\"";
        interactText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            weapon.PickUp();
        }
    }

    void HandleDoorInteraction(GameObject obj)
    {
        interactText.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (obj.GetComponent<DoorWithKey>())
            {
                obj.GetComponent<DoorWithKey>().Interact();
            }
            else if (obj.GetComponent<DoorWithLatch>())
            {
                obj.GetComponent<DoorWithLatch>().Interact();
            }
            else
            {
                obj.GetComponent<Door>().Interact();
            }
        }
    }

    void HandleDoorText(Collider _other)
    {
        interactText.GetComponent<Text>().text = "Press \"E\" to interact with the door";

        var col = _other.GetComponent<DoorCollider>();
        if (col.GetComponentInParent<DoorWithLatch>())
        {
            var doorWithLatch = col.GetComponentInParent<DoorWithLatch>();
            if (col.frontCollider && doorWithLatch.locked && doorWithLatch.triedToOpen)
            {
                interactText.GetComponent<Text>().text = "Locked from the other side";
            }            
        }
        else if (col.GetComponentInParent<DoorWithKey>())
        {
            var doorWithKey = col.GetComponentInParent<DoorWithKey>();
            if (!doorWithKey.hasKey && doorWithKey.triedToOpen)
            {
                interactText.GetComponent<Text>().text = "Requires key";
            }
        }
    }
}
