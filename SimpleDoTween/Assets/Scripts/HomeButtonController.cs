using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HomeButtonController : MonoBehaviour
{
    private readonly float _tweenTime = 0.2f;
    private readonly Vector3 _pressedScale = new Vector3(0.6f, 0.6f, 0.6f);

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        var sequence = DOTween.Sequence();
        
        sequence.Append(transform.DOScale(_pressedScale, _tweenTime));
        sequence.Join(transform.DORotate(new Vector3(0f, 0f, 360f),
            _tweenTime * 2, RotateMode.FastBeyond360));
        sequence.Append(transform.DOScale(Vector3.one, _tweenTime));
    }
}
