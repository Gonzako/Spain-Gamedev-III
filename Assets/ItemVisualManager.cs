using UnityEngine;

/// 
/// Copyright (c) 2021 All Rights Reserved
///
/// Any Doubts Email Me At contactgonzako@gmail.com
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class ItemVisualManager : MonoBehaviour
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
        Vector2 mitadPantalla = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 mouseDifference = (Vector2)Input.mousePosition - mitadPantalla;
    }

    #endregion
}
