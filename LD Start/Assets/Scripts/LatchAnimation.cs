using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class LatchAnimation : MonoBehaviour
{
    [SerializeField]
    Vector3 openPos;

    [SerializeField]
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);
    }

    public void PlayAnimation()
    {
        //transform.localPosition = openPos;
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOLocalMove(openPos, duration));
    }
}
