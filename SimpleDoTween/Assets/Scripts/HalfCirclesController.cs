using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HalfCirclesController : MonoBehaviour
{
    [SerializeField]
    private Transform innerHalf;
    [SerializeField]
    private Transform outerHalf;
    
    void Start()
    {
        innerHalf.DORotate(new Vector3(0f, 0f, 360f), 1f, RotateMode.FastBeyond360)
            .SetLoops(-1);
        
        outerHalf.DORotate(new Vector3(0f, 0f, -360f), 1f, RotateMode.FastBeyond360)
            .SetLoops(-1);
    }
}
