using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RopeManager : MonoBehaviour
{
    public int ropesCount;

    [SerializeField]
    UnityEvent FreedFromRopes;

    public int RopeDestroyed()
    {
        ropesCount--;
        return ropesCount;
    }

    public void AllRopesDestroyed()
    {
        FreedFromRopes?.Invoke();
    }
}
