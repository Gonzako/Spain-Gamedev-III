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
    int Qeue = 0;
    Coroutine moveRoutine;
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


    public IEnumerator MoveAllItemsRecursively(HexDirection dir)
    {
        while (Qeue > 0)
        {
            TargetToDispatch.Clear();
            HexCoordinates startingPoint = new HexCoordinates(dir.ToCoordChange().x * currentGrid.GridSize, dir.ToCoordChange().z * currentGrid.GridSize);
            var cell = currentGrid.GetCell(startingPoint);
            var checkedSpots = new HashSet<HexCell>();
            //SetupMovementRecursive(cell, checkedSpots, dir);
            SetupMovementIterative(dir);
            checkedSpots.Clear();
            for (int i = 0; i < TargetToDispatch.Count; i++)
            {
                if (TargetToDispatch[i] == null)
                    continue;
                StartCoroutine(TargetToDispatch[i]?.MoveDistance(dir, currentGrid.GridSize * 2 + 1));
                yield return null;
                //Debug.Log("Asked " + TargetToDispatch[i]?.gameObject + i + "To move");
            }
            TargetToDispatch.Clear();
            Qeue--;
        }
        moveRoutine = null;
        
    }

    public void MoveAllItems(int dir)
    {
        Debug.Log("Move all event called");
        Qeue++;
        if(moveRoutine == null)
            moveRoutine = StartCoroutine(MoveAllItemsRecursively((HexDirection)dir));
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

    private void SetupMovementIterative(HexDirection dir)
    {

        HexCoordinates startingPoint = new HexCoordinates(dir.ToCoordChange().x * currentGrid.GridSize, dir.ToCoordChange().z * currentGrid.GridSize);
        var cell = currentGrid.GetCell(startingPoint);

        for (int i = 0; i < 2*currentGrid.GridSize; i++)
        {
            Debug.Log("Went through " + i + "Iterations");
            cell = cell.GetNeighbor(dir.Opposite());
            if(cell == null)
            {
                Debug.Log("Reached end before hand");
                break;
            }
            if (cell.currentItem.currentHeldItem != null)
                TargetToDispatch.Add(cell.currentItem.currentHeldItem);

            var axisLeft = dir.Opposite().Next();
            var axisRight = dir.Opposite().Previous();

            var cellLeft = cell.GetNeighbor(axisLeft);
            var cellRight = cell.GetNeighbor(axisRight);

            while(cellLeft != null)
            {
                if (cellLeft.currentItem.currentHeldItem != null)
                    TargetToDispatch.Add(cellLeft.currentItem.currentHeldItem);
                cellLeft = cellLeft.GetNeighbor(axisLeft);

            }

            while (cellRight != null)
            {
                if (cellRight.currentItem.currentHeldItem != null)
                    TargetToDispatch.Add(cellRight.currentItem.currentHeldItem);
                cellRight = cellRight.GetNeighbor(axisRight);

            }
            
        }
    }
    #endregion
}
