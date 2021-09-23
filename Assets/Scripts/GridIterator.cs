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
    List<ItemHolderLogic> TargetToDispatch;
    #endregion

    #region UnityCallBacks

    void Awake()
    {

    }

    private void Start()
    {
        currentGrid = GetComponent<HexGrid>();
        TargetToDispatch = new List<ItemHolderLogic>(currentGrid.cellCount+3);

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


    public IEnumerator MoveAllItems(HexDirection dir)
    {
        TargetToDispatch.Clear();
        HexCoordinates startingPoint = new HexCoordinates(-dir.ToCoordChange().x * currentGrid.GridSize, -dir.ToCoordChange().z * currentGrid.GridSize);
        var cell = currentGrid.GetCell(startingPoint);
        var checkedSpots = new HashSet<HexCell>();
        SetupMovementRecursive(cell, checkedSpots, dir);
        checkedSpots.Clear();
        for (int i = 0; i < TargetToDispatch.Count; i++)
        {
            StartCoroutine(TargetToDispatch[i].MoveDistance(dir, currentGrid.GridSize*2+1));
            yield return null;
            Debug.Log("Asked " + TargetToDispatch[i].gameObject + i + "To move");
        }
        TargetToDispatch.Clear();
    }

    public void MoveAllItems(int dir)
    {
        Debug.Log("Move all event called");
        StartCoroutine(MoveAllItems((HexDirection)dir));
    }
    #endregion


    #region PrivateMethods
    private void SetupMovementRecursive(HexCell target, HashSet<HexCell> checkedSpots, HexDirection dir)
    {
        if (target.currentItem.currentHeldItem != null)
            TargetToDispatch.Add(target.currentItem.currentHeldItem);
        checkedSpots.Add(target);

        for (int i = 0; i < 6; i++)
        {
            var newTarget = target.GetNeighbor((HexDirection)i);
            if (!checkedSpots.Contains(newTarget) && newTarget != null)
            {
               SetupMovementRecursive(newTarget, checkedSpots, dir);
            }
        }
    }

    #endregion
}
