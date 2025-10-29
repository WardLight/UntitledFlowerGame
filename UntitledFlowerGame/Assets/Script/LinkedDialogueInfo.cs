using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class LinkedDialogueInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBubble;
    [SerializeField]
    private TextMeshPro dialogueMesh;
    [SerializeField]
    private List<string> dialogues;


    private Vector3 targetScale = new Vector3(0.3f, 0.3f, 0.3f);

    private int currentDialogueIndex = 0;
    private void Start()
    {
        dialogueBubble.transform.localScale = Vector3.zero;
        dialogueBubble.transform.rotation = Camera.main.transform.rotation;

    }

    public void ShowBubble()
    {
        dialogueMesh.text = dialogues[currentDialogueIndex];
        dialogueBubble.transform.DOScale(targetScale, 0.3f);
        currentDialogueIndex = (currentDialogueIndex + 1) % dialogues.Count;
    }

    public void HideBubble()
    {
        dialogueBubble.transform.DOScale(Vector3.zero, 0.3f);
    }
}
