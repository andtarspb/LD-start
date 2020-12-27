using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class KeyScript : MonoBehaviour
{
    public string keyName;

    [SerializeField]
    float pickupDuration;

    [SerializeField]
    DoorWithKey[] doors;

    private void Start()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);
    }
    public void PickUpKey()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].hasKey = true;
        }

        transform.parent = FindObjectOfType<PlayerMovement>().transform;
        transform.DOLocalRotate(new Vector3(0f, 0f, 90f), pickupDuration / 2).SetUpdate(true);
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOLocalMove(new Vector3(-0.5f, 0.5f, 0.25f), pickupDuration).SetEase(Ease.OutBack).SetUpdate(true));
        mySequence.AppendCallback(() => Destroy(gameObject));
    }
}
