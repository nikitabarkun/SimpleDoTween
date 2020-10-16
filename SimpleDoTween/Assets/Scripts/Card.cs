using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour
{
    private const float GettingFromDeckDuration = 0.8f;
    private const float ReturningToDeckDuration = 0.4f;
    private const float HoverReturningDuration = 0.4f;
    
    [SerializeField] 
    private Transform centerPoint;
    
    private Vector3 _defaultPosition;

    private bool _isTakenFromDeck;

    private void Start()
    {
        _defaultPosition = transform.position;
    }

    public void OnClick()
    {
        var sequence = DOTween.Sequence();
        _isTakenFromDeck = !_isTakenFromDeck;
        
        if (_isTakenFromDeck)
        {
            sequence.Join(transform.DOMove(centerPoint.position, GettingFromDeckDuration));
            sequence.Join(transform.DORotate(new Vector3(0f, 360f, 10f),
                GettingFromDeckDuration, RotateMode.FastBeyond360));
            sequence.Join(transform.DOScale(new Vector3(2f, 2f), GettingFromDeckDuration));
        }
        else
        {
            sequence.Join(transform.DOMove(_defaultPosition, ReturningToDeckDuration));
            sequence.Join(transform.DORotate(new Vector3(0f, -360f, 0f),
                ReturningToDeckDuration, RotateMode.FastBeyond360));
            sequence.Join(transform.DOScale(new Vector3(1f, 1f), ReturningToDeckDuration));
        }
    }
    
    public void OnPointerEnter()
    {
        if (!_isTakenFromDeck)
            transform.DOMove(new Vector3(transform.position.x,
                transform.position.y + 20f), HoverReturningDuration);
    }

    public void OnPointerExit()
    {
        if (!_isTakenFromDeck) 
            transform.DOMove(_defaultPosition, HoverReturningDuration);
    }
}
