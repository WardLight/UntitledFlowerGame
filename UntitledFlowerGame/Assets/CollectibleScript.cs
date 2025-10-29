using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CollectibleScript : MonoBehaviour
{
    [SerializeField] CollectibleType collectibleType;

    public void OnCollect()
    {
        Destroy(gameObject);
    }
    
    public CollectibleType getCollectibleType()
    {
        return collectibleType;
    }
}
