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


public class SquareGrid
{

    #region PublicFields

    #endregion

    #region PrivateFields
    private int width;
    private int height;
    private int[,] internalMatrix;
    #endregion


    #region PublicMethods

    public SquareGrid(int width, int height)
    {
        this.width = width;
        this.height = height;

        internalMatrix = new int[width, height];

        for (int i = 0; i < internalMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < internalMatrix.GetLength(1); j++)
            {

            }
        }
    }

    #endregion


    #region PrivateMethods


    #endregion
}
