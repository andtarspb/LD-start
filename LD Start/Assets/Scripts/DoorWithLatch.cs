using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class DoorWithLatch : Door
{
    public bool locked = true;
    public bool triedToOpen;

    [SerializeField]
    float shakeDegree;
    [SerializeField]
    float shakeDuration;

    [SerializeField]
    LatchAnimation latch;

    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);
        isInteractable = true;
        triedToOpen = false;
    }

    public new void Interact()
    {
        if (isInteractable)
        {
            if (currentState == DoorState.Closed)
            {
                if (currentPlayerPos == PlayerPos.Front)
                {
                    if (locked)
                    {
                        //Debug.Log("locked from the other side");
                        ShakeDoor(shakeDegree, shakeDuration);
                        triedToOpen = true;
                    }
                    else
                    {
                        RotateDoor(-90f, duration);
                        currentState = DoorState.OpenedBackward;
                    }
                }
                else if (currentPlayerPos == PlayerPos.Back)
                {
                    if (locked)
                    {
                        OpenLatch();
                        locked = false;
                    }
                    else
                    {
                        RotateDoor(90f, duration);
                    }               
                   
                    currentState = DoorState.OpenedForward;
                }
            }
            else if (currentState == DoorState.OpenedBackward)
            {
                RotateDoor(90f, duration);
                currentState = DoorState.Closed;
            }
            else if (currentState == DoorState.OpenedForward)
            {
                RotateDoor(-90f, duration);
                currentState = DoorState.Closed;
            }
        }
    }

    void OpenLatch()
    {
        isInteractable = false;

        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendCallback(() => latch.PlayAnimation());
        mySequence.AppendInterval(latch.duration);
        mySequence.AppendCallback(() => RotateDoor(90f, duration));
    }

    void ShakeDoor(float degrees, float length)
    {
        isInteractable = false;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DORotate(new Vector3(0f, -degrees, 0f), length, RotateMode.LocalAxisAdd));
        mySequence.Append(transform.DORotate(new Vector3(0f, degrees * 1.5f, 0f), length, RotateMode.LocalAxisAdd));
        mySequence.Append(transform.DORotate(new Vector3(0f, -degrees/2, 0f), length, RotateMode.LocalAxisAdd));
        mySequence.AppendCallback(() => isInteractable = true);
    }
}
