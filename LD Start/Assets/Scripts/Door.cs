using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public enum DoorState
    {
        Closed,
        OpenedForward,
        OpenedBackward
    };

    public enum PlayerPos
    {
        Far,
        Front,
        Back        
    }

    [SerializeField]
    public float duration;
    [SerializeField]
    public DoorState currentState;
    [SerializeField]
    public PlayerPos currentPlayerPos;

    public bool isInteractable;

    [SerializeField]
    bool openBackwards;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);
        isInteractable = true;
    }


    public void Interact()
    {
        if (isInteractable)
        {
            if (currentState == DoorState.Closed)
            {
                if (currentPlayerPos == PlayerPos.Front)
                {
                    RotateDoor(-90f, duration);
                    currentState = DoorState.OpenedBackward;
                }
                else if (currentPlayerPos == PlayerPos.Back)
                {
                    RotateDoor(90f, duration);
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

    public void RotateDoor(float degrees, float length)
    {
        isInteractable = false;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DORotate(new Vector3(0f, degrees * DirToOpen(), 0f), length, RotateMode.LocalAxisAdd));
        mySequence.AppendCallback(() => isInteractable = true);
    }

    int DirToOpen()
    {
        return (openBackwards) ? -1 : 1;
    }
}
