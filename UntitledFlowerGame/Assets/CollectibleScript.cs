using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CollectibleScript : MonoBehaviour
{
    [FormerlySerializedAs("flowerType")] [SerializeField] CollectibleType collectibleType;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollect()
    {
        Destroy(gameObject);
    }
    
    public CollectibleType getCollectibleType()
    {
        return collectibleType;
    }
}
