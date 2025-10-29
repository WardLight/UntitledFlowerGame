using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public enum CollectibleType
{
    Lisianthus,
    Rose,
    Paquerette
}

public class PlayerInventory : MonoBehaviour
{
    private bool[] Inventory = new []{false, false, false};
    
    [SerializeField] List<GameObject> Items;
    
    // Start is called before the first frame update
    public void AddCollectible(CollectibleType type)
    {
        Inventory[(int)type] = true;
        Items[(int)type].SetActive(true);
    }

    public void RemoveCollectible(CollectibleType type)
    {
        Inventory[(int)type] = false;
        Items[(int)type].SetActive(false);
    }
}
