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


public class ItemSpawner : MonoBehaviour
{

    #region PublicFields

    #endregion

    #region PrivateFields
    [SerializeField] ScriptableObjectArchitecture.GameEvent OnPlayerLose;
    [SerializeField] ItemHolderLogic ItemPrefab;
    HexGrid currentGrid;
    private int fillCount = 0;
    #endregion

    #region UnityCallBacks

    void Awake()
    {
        currentGrid = GetComponent<HexGrid>();
    }

    private void Start()
    {
        CreateSpot(FindEmptySpot());
        CreateSpot(FindEmptySpot());
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

    public void AddRandomItem()
    {
        if(fillCount == currentGrid.cellCount)
        {
            OnPlayerLose?.Raise();
        }
        CreateSpot(FindEmptySpot());
    }

    #endregion


    #region PrivateMethods

    private void CreateSpot(HexCell pos)
    {

        var newInstance = GameObject.Instantiate(ItemPrefab);
        newInstance.PlaceInHex(pos);
        newInstance.transform.localPosition = -Vector3.forward;
        fillCount++;
        if(UnityEngine.Random.value > 0.8f)
        {
            newInstance.Value *= 2;
        }
    }

    private HexCell FindEmptySpot()
    {
        HexCell target = currentGrid.GetCell(RandomHexSpot());
        while(target == null || target.currentItem.currentHeldItem != null  )
        {
            target = currentGrid.GetCell(RandomHexSpot());
        }
        return target;
    }

    private HexCoordinates RandomHexSpot()
    {
        return new HexCoordinates(UnityEngine.Random.Range(-currentGrid.GridSize, currentGrid.GridSize + 1), UnityEngine.Random.Range(-currentGrid.GridSize, currentGrid.GridSize + 1));
    }


    private void ItemHolderLogic_OnItemCollide((ItemHolderLogic, ItemHolderLogic) obj)
    {
        if (obj.Item1.Value == obj.Item2.Value)
        {
            fillCount--;
        }
    }
    #endregion
}
