using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    door.GetComponent<Door>().Interact();
                }
            }
        }
    }
}
