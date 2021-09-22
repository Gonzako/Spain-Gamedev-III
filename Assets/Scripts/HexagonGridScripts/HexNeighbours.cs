using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// 
/// Copyright (c) 2020 All Rights Reserved
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public enum HexDirection
{
	NE, E, SE, SW, W, NW
}


public static class HexDirectionExtensions
{

	private static Vector3Int[] DirectionToCoordChange = new Vector3Int[]{ new Vector3Int(+1, 0, -1),
		new Vector3Int(+1, -1, 0), new Vector3Int(0, -1, +1), new Vector3Int(-1, 0, +1),
		new Vector3Int(-1, +1, 0), new Vector3Int(0,+1,-1)};


	public static HexDirection Opposite(this HexDirection direction)
	{
		return (int)direction < 3 ? (direction + 3) : (direction - 3);
	}

	public static HexDirection Previous(this HexDirection direction)
	{
		return direction == HexDirection.NE ? HexDirection.NW : (direction - 1);
	}

	public static HexDirection Next(this HexDirection direction)
	{
		return direction == HexDirection.NW ? HexDirection.NE : (direction + 1);
	}

	public static Vector3Int ToCoordChange(this HexDirection dir)
    {
		return DirectionToCoordChange[(int)dir];
    }


}