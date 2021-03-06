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
    public static event Action<ItemHolderLogic> OnFusion;
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
            if(obj.Item1.Value == 256)
            {
                obj.Item2.Value = 2;
            }
            else
            {
                obj.Item2.Value *= 2;
            }
            obj.Item1.PlaceInHex(null);
            Destroy(obj.Item1.gameObject, 0.2f);

            OnFusion?.Invoke(obj.Item2);
        }
    }

    #endregion
}
