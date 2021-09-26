using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// 
/// Copyright (c) 2021 All Rights Reserved
///
/// Any Doubts Email Me At contactgonzako@gmail.com
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class ScoreTracker : MonoBehaviour
{

    #region PublicFields

    #endregion

    #region PrivateFields
    private int Score = 0;
    private TextMeshProUGUI text;
    #endregion

    #region UnityCallBacks

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {

    }

    void OnEnable()
    {
        FusionManager.OnFusion += FusionManager_OnFusion;
    }


    private void OnDisable()
    {
        FusionManager.OnFusion -= FusionManager_OnFusion;
    }


    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods

    private void FusionManager_OnFusion(ItemHolderLogic obj)
    {
        Score += obj.Value;
        text.text = Score.ToString();
    }

    #endregion
}
