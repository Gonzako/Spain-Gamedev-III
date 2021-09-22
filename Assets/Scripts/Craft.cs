using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Craft", menuName = "Objects/Craft")]
public class Craft : ScriptableObject
{   

    public List<ItemDescriptor> items = new List<ItemDescriptor>();

    /*

        Elements 0-1: Input

        Elements 2-3: Output

    */
}
