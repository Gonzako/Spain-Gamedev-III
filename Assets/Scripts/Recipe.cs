using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{

    [Header("Input Items")]
    public ItemDescriptor input_item1;
    public ItemDescriptor input_item2;

    [Header("")]
    [Header("Output Items")]
    public ItemDescriptor output_item1;
    public ItemDescriptor output_item2;

}
