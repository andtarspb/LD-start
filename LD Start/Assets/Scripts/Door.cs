using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    enum DoorState
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
    float duration;
    [SerializeField]
    DoorState currentState;
    [SerializeField]
    public PlayerPos currentPlayerPos;

    bool isInteractable;

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
                    RotateDoor(-90f);
                    currentState = DoorState.OpenedBackward;
                }
                else if (currentPlayerPos == PlayerPos.Back)
                {
                    RotateDoor(90f);
                    currentState = DoorState.OpenedForward;
                }
            }
            else if (currentState == DoorState.OpenedBackward)
            {
                RotateDoor(90f);
                currentState = DoorState.Closed;
            }
            else if (currentState == DoorState.OpenedForward)
            {
                RotateDoor(-90f);
                currentState = DoorState.Closed;
            }
        }        
    }

    void RotateDoor(float degrees)
    {
        isInteractable = false;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DORotate(new Vector3(0f, degrees, 0f), duration, RotateMode.LocalAxisAdd));
        mySequence.AppendCallback(() => isInteractable = true);
    }
}
