using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// 
/// Copyright (c) 2021 All Rights Reserved
///
/// Any Doubts Email Me At contactgonzako@gmail.com
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class MultiSceneManager : MonoBehaviour
{
    #region PublicFields

    #endregion

    #region PrivateFields

    private const string UIName = "UIScene";
    #endregion

    #region UnityCallBacks

    void Awake()
    {

    }

    void Start()
    {
        if (SceneManager.GetSceneByName(UIName).isLoaded == false)
        {
            SceneManager.LoadSceneAsync(UIName, LoadSceneMode.Additive);
        }
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
