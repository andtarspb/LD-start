using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class DrawbridgeManager : RopeManager
{
    [SerializeField]
    GameObject drawbridge;

    [SerializeField]
    float drawDuration = 1;

    private void Start()
    {
        DOTween.Init(true, true, LogBehaviour.ErrorsOnly);
    }

    public void DrawTheBridge()
    {
        //Debug.Log("draw the bridge!");
        if (drawbridge != null)
        {
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(drawbridge.transform.DOLocalRotate(Vector3.zero, drawDuration).SetEase(Ease.OutBack).SetUpdate(true));
        }
        
    }


}
