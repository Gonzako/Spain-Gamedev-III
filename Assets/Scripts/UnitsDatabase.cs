using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UnitsDatabase", menuName = "UnitsDatabase")]
public class UnitsDatabase : ScriptableObject
{

    public List<UnitColor> units = new List<UnitColor>();

}
