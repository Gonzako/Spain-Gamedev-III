using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingDictionary : MonoBehaviour
{

    private Dictionary<(ItemDescriptor, ItemDescriptor), (ItemDescriptor, ItemDescriptor)> dictionary = new Dictionary<(ItemDescriptor, ItemDescriptor), (ItemDescriptor, ItemDescriptor)>();



    public void AddCraftsSO(CraftTable SO) // SO = ScriptableObject
    {
        foreach(Recipe r in SO.recipes)
        {
            AddRecipeToDictionary(r.input_item1, r.input_item2, r.output_item1, r.output_item2);
        }
    }

    void AddRecipeToDictionary(ItemDescriptor i1, ItemDescriptor i2, ItemDescriptor o1, ItemDescriptor o2)
    {
        dictionary.Add((i1, i2) , (o1, o2));
    }
}
