using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    [SerializeField] AudioSource flowerSuccessAudio;
    [SerializeField] CollectibleType collectibleTarget;
    
    [SerializeField] CollectibleType collectibleTarget;
    [SerializeField] GameObject loveEffect;
    [SerializeField] GameObject badEffect;

    [SerializeField] SelfDialogue selfDialogueScript;
    [SerializeField] LinkedDialogue linkedDialogueScript;
    [SerializeField] LinkedDialogueInfo linkedDialogueInfoScript;
    // Start is called before the first frame update
    public CollectibleType getCollectibleTarget()
    {
        return collectibleTarget;
    }

    public void OnQuestComplete()
    {
        GameObject effect = Instantiate(loveEffect, transform.position + Vector3.up, Quaternion.identity, transform);
        if (selfDialogueScript != null)
        {
            selfDialogueScript.HideComplitelyBubble();
        }
        if (linkedDialogueScript != null)
        {
            linkedDialogueScript.HideComplitelyBubble();
        }
        if (linkedDialogueInfoScript != null)
        {
            linkedDialogueInfoScript.HideComplitelyBubble();
        }
        if (flowerSuccessAudio != null)
            flowerSuccessAudio.Play();
    }
    
    public void OnQuestFailed()
    {
        Debug.Log("Quest failed");
    }
}
