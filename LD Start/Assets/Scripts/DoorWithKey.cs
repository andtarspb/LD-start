using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DoorWithKey : Door
{
    public bool hasKey;
    public bool triedToOpen;

    [SerializeField]
    public float shakeDegree = 2f;
    [SerializeField]
    public float shakeDuration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);
        isInteractable = true;
        triedToOpen = false;
        hasKey = false;
    }

    public new void Interact()
    {
        if (isInteractable)
        {
            if (currentState == DoorState.Closed)
            {
                if (!hasKey)
                {
                    ShakeDoor(shakeDegree, shakeDuration);
                    triedToOpen = true;

                    //Debug.Log("need key");
                }
                else
                {
                    //Debug.Log("opened with key");
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

    public void ShakeDoor(float degrees, float length)
    {
        isInteractable = false;

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DORotate(new Vector3(0f, -degrees * DirToOpen(), 0f), length, RotateMode.LocalAxisAdd));
        mySequence.Append(transform.DORotate(new Vector3(0f, degrees * 1.5f * DirToOpen(), 0f), length, RotateMode.LocalAxisAdd));
        mySequence.Append(transform.DORotate(new Vector3(0f, -degrees * DirToOpen() / 2, 0f), length, RotateMode.LocalAxisAdd));
        mySequence.AppendCallback(() => isInteractable = true);
    }
}
