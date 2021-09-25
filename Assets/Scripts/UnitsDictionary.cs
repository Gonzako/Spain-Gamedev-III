using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsDictionary : MonoBehaviour
{
    public IReadOnlyDictionary<int, UnitToVisualValue> Data => dictionary;

    private Dictionary<int, UnitToVisualValue> dictionary = new Dictionary<int, UnitToVisualValue>();

    [SerializeField] UnitsToVisualDatabase  data;

    private void Start()
    {
        
        AddUnitsDatabase(data);
    }



    void AddUnitsDatabase(UnitsToVisualDatabase input) // Función para agregar la base de datos de colores de valores al dictionario.
    {
        foreach(UnitToVisualValue u in input.units)
        {
            if (dictionary.ContainsKey(u.value))
                continue;
            dictionary.Add(u.value, u);
        }
    }

}
