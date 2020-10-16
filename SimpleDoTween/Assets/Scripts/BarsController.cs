using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BarsController : MonoBehaviour
{
    [SerializeField]
    private Transform[] bars;

    private void Start()
    {
        StartCoroutine(SetLoops());
    }

    private IEnumerator SetLoops()
    {
        for (int i = 0; i < bars.Length; i++)
        {
            var sequence = DOTween.Sequence();
            sequence.SetLoops(-1);
            
            sequence.Append(bars[i].DOScale(new Vector3(1f,
                1.6f), 0.2f));
            sequence.Append(bars[i].DOScale(new Vector3(1f,
                1.0f), 0.2f));
            
            sequence.AppendInterval(0.6f);
            
            yield return new WaitForSeconds(0.1f);
        }
    }
}
