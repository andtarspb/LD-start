using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : MonoBehaviour
{
    [SerializeField]
    float range;

    [SerializeField]
    int damage;

    [SerializeField]
    string ropeTag = "rope";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            GameObject objectToInteract = hit.transform.gameObject;
            if (objectToInteract.CompareTag(ropeTag))
            {
                HandleRopeAttack(objectToInteract);
            }
        }
        
    }

    void HandleRopeAttack(GameObject obj)
    {
        RopeScript rope = obj.GetComponent<RopeScript>();

        if (rope != null)
        {
            rope.DestroyTheRope();
        }

        Destroy(obj);
    }
}
