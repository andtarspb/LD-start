using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BoxHangerManager : RopeManager
{
    [SerializeField]
    GameObject box;

    [SerializeField]
    Vector3 moveTo;

    [SerializeField]
    float fallDiration = 1;

    private void Start()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);
    }

    public void StartBoxFall()
    {
        //Debug.Log("draw the bridge!");
        if (box != null)
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(box.transform.DOLocalMove(moveTo, fallDiration).SetEase(Ease.OutBack).SetUpdate(true));
        }
        
    }


}
