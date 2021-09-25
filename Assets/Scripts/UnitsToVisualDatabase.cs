using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UnitsDatabase", menuName = "UnitsDatabase")]
public class UnitsToVisualDatabase : ScriptableObject
{

    public List<UnitToVisualValue> units = new List<UnitToVisualValue>();

}
