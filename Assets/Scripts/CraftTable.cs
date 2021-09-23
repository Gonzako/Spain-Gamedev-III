using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crafts", menuName = "GameData/Crafts")]
public class CraftTable : ScriptableObject
{   

    public List<Recipe> recipes = new List<Recipe>();

}
