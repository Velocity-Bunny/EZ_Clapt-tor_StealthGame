using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor;

// This will be the place for the player to hold their items.

using UnityEngine;
[Serializable]
public class CheeseInventory
{
    public int id;
    public string cheeseDesc;

    public Sprite icon;
    
    public object Cheese { get; set; }

    
    public Dictionary<int, string> cheese = new Dictionary<int, string>();
    
    
    public CheeseInventory(int _id, string _cheeseDesc, Sprite _icon)
    {
        
        this.id = _id;
        this.cheeseDesc = _cheeseDesc;
        _icon = Resources.Load<Sprite>("Resources/Cheese");
        this.icon = _icon;

    }
    
}
