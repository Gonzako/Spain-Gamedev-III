using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2021 All Rights Reserved
///
/// Any Doubts Email Me At contactgonzako@gmail.com
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class FusionManager : MonoBehaviour
{

    #region PublicFields

    #endregion

    #region PrivateFields

    #endregion

    #region UnityCallBacks

    void Awake()
    {

    }

    void FixedUpdate()
    {

    }

    void OnEnable()
    {
        ItemHolderLogic.OnItemCollide += ItemHolderLogic_OnItemCollide;
    }


    private void OnDisable()
    {

        ItemHolderLogic.OnItemCollide -= ItemHolderLogic_OnItemCollide;
    }


    #endregion

    #region PublicMethods



    #endregion


    #region PrivateMethods
    //if values are equal destroy the 1st and increment the other one
    private void ItemHolderLogic_OnItemCollide((ItemHolderLogic, ItemHolderLogic) obj)
    {
        if(obj.Item1.Value == obj.Item2.Value)
        {
            obj.Item2.Value *= 2;
            Destroy(obj.Item1.gameObject, 0.1f);
        }
    }

    #endregion
}
