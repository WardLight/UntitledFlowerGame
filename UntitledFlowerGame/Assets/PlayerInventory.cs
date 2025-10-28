using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CollectibleType
{
    Lisianthus,
    Rose,
    Paquerette
}

public class PlayerInventory : MonoBehaviour
{
    private List<CollectibleType> Inventory  = new List<CollectibleType>();
    
    // Start is called before the first frame update
    public void AddCollectible(CollectibleType Type)
    {
        Inventory.Append(Type);
        
    }

    public void RemoveCollectible(CollectibleType Type)
    {
        Inventory.Remove(Type);
    }
}
