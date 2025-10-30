using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    [SerializeField] AudioSource flowerSuccessAudio;
    [SerializeField] CollectibleType collectibleTarget;

    [SerializeField] ParticleSystem loveEffect;
    [SerializeField] ParticleSystem badEffect;

    [SerializeField] SelfDialogue selfDialogueScript;
    [SerializeField] LinkedDialogue linkedDialogueScript;
    [SerializeField] LinkedDialogueInfo linkedDialogueInfoScript;


    [SerializeField] string missionName;

    // Start is called before the first frame update
    public CollectibleType getCollectibleTarget()
    {
        return collectibleTarget;
    }

    public void OnQuestComplete()
    {
        if (missionName == "LoveMission")
        {
            GameManager.LoveMissionComplete = true;
        }
        else if (missionName == "SadMission")
        {
            GameManager.SadMissionComplete = true;
        }
        else if (missionName == "PartyMission")
        {
            GameManager.PartyMissionComplete = true;
        }


        loveEffect.Play();
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
        badEffect.Play();
    }
}
