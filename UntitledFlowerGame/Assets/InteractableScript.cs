using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    [SerializeField] AudioSource flowerSuccessAudio;
    [SerializeField] CollectibleType collectibleTarget;
    
    // Start is called before the first frame update
    public CollectibleType getCollectibleTarget()
    {
        return collectibleTarget;
    }

    public void OnQuestComplete()
    {
        Debug.Log("Quest Success");
        if (flowerSuccessAudio != null)
            flowerSuccessAudio.Play();
    }
    
    public void OnQuestFailed()
    {
        Debug.Log("Quest failed");
    }
}
