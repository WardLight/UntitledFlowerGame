using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class detectionFish : MonoBehaviour
{

    [SerializeField] SelfDialogue selfDialogueScript;

    private bool hasMoved = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Poisson" && !hasMoved)
        {
            hasMoved = true;
            selfDialogueScript.HideComplitelyBubble();
            Transform parentTransform = transform.parent;
            Vector3 targetPosition = parentTransform.position + new Vector3(2f, 0f, 0f);
            parentTransform.DOMove(targetPosition, 0.5f);

        }
    }
}
