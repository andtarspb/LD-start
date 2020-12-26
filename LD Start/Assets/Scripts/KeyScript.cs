using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public string keyName;

    [SerializeField]
    DoorWithKey[] doors; 


    public void PickUpKey()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].hasKey = true;
        }

        Destroy(gameObject);
    }
}
