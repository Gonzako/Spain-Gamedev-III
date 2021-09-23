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


public class GridIterator : MonoBehaviour
{

    #region PublicFields

    #endregion

    #region PrivateFields

    HexGrid currentGrid;

    #endregion

    #region UnityCallBacks

    void Awake()
    {

    }

    private void Start()
    {
        currentGrid = GetComponent<HexGrid>();
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

    public void MoveAllItems(HexDirection dir)
    {
        HexCoordinates startingPoint = new HexCoordinates(-dir.ToCoordChange().x * currentGrid.GridSize, -dir.ToCoordChange().z * currentGrid.GridSize);
        var cell = currentGrid.GetCell(startingPoint);
        var checkedSpots = new HashSet<HexCell>();
        StartCoroutine(SetupMovementRecursive(cell, checkedSpots, dir));
        checkedSpots.Clear();
    }
    #endregion


    #region PrivateMethods
    private IEnumerator SetupMovementRecursive(HexCell target, HashSet<HexCell> checkedSpots, HexDirection dir)
    {
        StartCoroutine(target.currentItem.currentHeldItem.MoveDistance(dir, currentGrid.GridSize + 1));
        checkedSpots.Add(target);

        for (int i = 0; i < 6; i++)
        {
            yield return null;
            var newTarget = target.GetNeighbor((HexDirection)i);
            if (!checkedSpots.Contains(newTarget) && newTarget != null)
            {
                StartCoroutine(SetupMovementRecursive(newTarget, checkedSpots, dir));
            }
        }
    }

    #endregion
}
