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


public class HexGrid : MonoBehaviour
{

    #region PublicFields



    #endregion

    #region PrivateFields
    [SerializeField] HexCell cellPrefab;
    Dictionary<HexCoordinates, HexCell> cellDictionary = new Dictionary<HexCoordinates, HexCell>();
    [SerializeField] int gridSize = 3;
    [SerializeField] Transform parent;
    [SerializeField, Range(0,2)] float sizeY = 1f;
    [SerializeField, Range(0, 2)] float sizeX = 1f;
    [SerializeField] bool allowWrap = true;
    int maxEdgeCount;

    #endregion

    #region UnityCallBacks

    void Awake()
    {
        //Create logic cells

        generateGrid();

    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var point = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward*0.5f);

        }
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

    private void generateGrid()
    {
        //Thanks to https://www.redblobgames.com/grids/hexagons/implementation.html

        for (int q = -gridSize; q <= gridSize; q++)
        {
            int r1 = Mathf.Max(-gridSize, -q - gridSize);
            int r2 = Mathf.Min(gridSize, -q + gridSize);
            for (int r = r1; r <= r2; r++)
            {
                CreateCell(q, r);
            }
        }

        //this part is home crafted. I know its unoptimized
        foreach(HexCoordinates n in cellDictionary.Keys)
        {
            SetNeighbors(n);
        }
    }


    private HexCoordinates CreateCell(int x, int z)
    {
        #region Position and Instantiation

        Layout targetLayout = new Layout(Layout.flat, new Point(sizeX, sizeY), new Point());
        var pos = targetLayout.HexToPixel(new Hex(x, z, -x - z));
        var position = new Vector3((float)pos.x, -(float)pos.y);


        HexCell cell = Instantiate(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;

        var hexCoords = new  HexCoordinates(x, z);
        cell.coords = hexCoords;
        cellDictionary.Add(hexCoords, cell);

        return hexCoords;
        #endregion


    }

    private void SetNeighbors(HexCoordinates coords)
    {
        if (cellDictionary.TryGetValue(coords, out HexCell target))
        {
            for (int i = 0; i < 6; i++)
            {
                //Dont recalculate if already set neighbour

                if (target.GetNeighbor((HexDirection)i) != null)
                {
                    continue;
                }
                if(cellDictionary.TryGetValue(coords.getNeighbor((HexDirection)i), out HexCell neighbour))
                {

                    target.SetNeighbor((HexDirection)i, neighbour);
                    //Debug.LogWarning("normalNeighbour set");
                }
                else if(allowWrap)
                {
                    HexCoordinates opositeNeighbour = new HexCoordinates(99,99);
                    switch ((HexDirection)i)
                    {
                        case HexDirection.NE:
                            opositeNeighbour = coords.reflectY();
                            break;
                        case HexDirection.SE:
                            opositeNeighbour = coords.reflectZ();
                            break;
                        case HexDirection.S:
                            opositeNeighbour = coords.reflectX();
                            break;
                        case HexDirection.SW:

                            opositeNeighbour = coords.reflectY();
                            break;
                        case HexDirection.NW:
                            opositeNeighbour = coords.reflectZ();
                            break;
                        case HexDirection.N:
                            opositeNeighbour = coords.reflectX();
                            break;
                    }
                    if(cellDictionary.TryGetValue(opositeNeighbour, out HexCell wrapCell))
                    {
                        target.SetNeighbor((HexDirection)i, wrapCell);
                        //Debug.Log("Oposite neighbour" + opositeNeighbour.ToString() + " set in direction " + ((HexDirection)i).ToString() + " for " + coords);
                    }
                    else
                    {
                        Debug.LogError("Something went wrong when trying to compute position " + coords + " in direction " + ((HexDirection)i).ToString());
                    }

                }
            }
        }
    }

    #endregion
}
