using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour
{
    [SerializeField]
    RopeManager ropeManager;

    // Start is called before the first frame update
    void Start()
    {
        ropeManager.ropesCount++;
    }

    public void DestroyTheRope()
    {
        ropeManager.RopeDestroyed();

        if (ropeManager.ropesCount == 0)
        {
            ropeManager.AllRopesDestroyed();
        }

        Destroy(gameObject);
    }
}
