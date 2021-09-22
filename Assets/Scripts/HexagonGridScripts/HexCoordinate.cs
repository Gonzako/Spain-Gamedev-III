using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
	[SerializeField]
	private int x, z;

	public int X { get { return x; } }

	public int Z { get => z; }

	public int Y
	{
		get
		{
			return -X - Z;
		}
	}


	public HexCoordinates(int x, int z)
	{
		this.x = x;
		this.z = z;
	}

	public static HexCoordinates FromOffsetCoordinates(int x, int z)
	{
		return new HexCoordinates(x - z / 2, z);
	}

	public HexCoordinates reflectX()
    {
		return new HexCoordinates(this.X, this.Y);
    }
	public HexCoordinates reflectY()
    {
		return new HexCoordinates(this.Z, this.X);
    }
	public HexCoordinates reflectZ()
    {
		return new HexCoordinates(this.Y, this.Z);
    }

	public HexCoordinates getNeighbor(HexDirection dir)
    {
		return new HexCoordinates(this.x + dir.ToCoordChange().x, this.z + dir.ToCoordChange().z);
    }


	public override string ToString()
	{
		return "(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ")";
	}

	public string ToStringOnSeparateLines()
	{
		return X.ToString() + "\n" + Y.ToString() + "\n"  + Z.ToString();
	}
}