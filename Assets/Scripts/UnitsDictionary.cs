using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsDictionary : MonoBehaviour
{

    private Dictionary<int, Color> dictionary = new Dictionary<int, Color>();



    public void AddUnitsDatabase(UnitsDatabase input) // Función para agregar la base de datos de colores de valores al dictionario.
    {
        foreach(UnitColor u in input.units)
        {
            dictionary.Add(u.value, u.Main_Color);
        }
    }

}
