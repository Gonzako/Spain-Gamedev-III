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


public class UIResourceShower : MonoBehaviour
{

    #region PublicFields
    public int useValue = 3;
    public int DirectionID;
    public DirectionResources dirs;
    #endregion

    #region PrivateFields

    private TMPro.TextMeshProUGUI text;
    #endregion


    #region UnityCallBacks

    void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
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

    private void Update()
    {
        text.text = dirs.DirResources[DirectionID].ToString();
    }
    #endregion

    #region PublicMethods

    public void GainResource(int dir)
    {
            return;

        useValue++;
        text.text = useValue.ToString();
    }

    public void LoseResource(int dir)
    {
            return;
        useValue--;
        text.text = useValue.ToString();
    }
    #endregion


    #region PrivateMethods


    #endregion
}
