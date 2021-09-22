using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafts", menuName = "Objects/Crafts")]
public class Crafts : ScriptableObject
{   

    public List<Recipe> recipes = new List<Recipe>();

}
