using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingDictionary : MonoBehaviour
{

    Dictionary<(ItemDescriptor, ItemDescriptor), (ItemDescriptor, ItemDescriptor)> dictionary = new Dictionary<(ItemDescriptor, ItemDescriptor), (ItemDescriptor, ItemDescriptor)>();


    void AddCraftToDictionary(Craft SO)
    {
        dictionary.Add((SO.items[0], SO.items[1]) , (SO.items[2], SO.items[3]));
    }
}
