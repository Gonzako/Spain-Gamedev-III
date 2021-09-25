using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsDictionary : MonoBehaviour
{

    private Dictionary<int, UnitToVisualValue> dictionary = new Dictionary<int, UnitToVisualValue>();



    public void AddUnitsDatabase(UnitsToVisualDatabase input) // Función para agregar la base de datos de colores de valores al dictionario.
    {
        foreach(UnitToVisualValue u in input.units)
        {
            dictionary.Add(u.value, u);
        }
    }

}
