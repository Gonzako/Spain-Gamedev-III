﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour
{

    public HexCoordinates coords;



    [SerializeField]
    HexCell[] neighbors = new HexCell[6];

    public HexCell GetNeighbor(HexDirection direction)
    {
        return neighbors[(int)direction];
    }

    public void SetNeighbor(HexDirection direction, HexCell cell)
    {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
    }
}
