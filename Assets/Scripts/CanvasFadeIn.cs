using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// 
/// Copyright (c) 2021 All Rights Reserved
///
/// Any Doubts Email Me At contactgonzako@gmail.com
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class CanvasFadeIn : MonoBehaviour
{

    #region PublicFields
    [SerializeField]
    private float FadeTime = 0.5f;
    #endregion

    #region PrivateFields

    #endregion

    #region UnityCallBacks

    void Awake()
    {

    }

    private void Start()
    {
        var alpha = GetComponent<CanvasGroup>();
        alpha.alpha = 0;
        alpha.DOFade(1, FadeTime).SetEase(Ease.InQuint);
    }
    void FixedUpdate()
    {

    }

    void OnEnable()
    {

    }


    private void OnDisable()
    {

    }


    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods


    #endregion
}
