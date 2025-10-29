using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class LinkedDialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBubble;
    [SerializeField]
    private TextMeshPro dialogueMesh;
    [SerializeField]
    private float timePerDialogue = 2f;
    [SerializeField]
    private List<string> dialogues;
    [SerializeField]
    private LinkedDialogueInfo otherDialogue;

    private int currentDialogueIndex = 0;
    private float timer = 0f;

    private bool isFirstCharaTurn = false;

    private Vector3 targetScale = new Vector3(0.3f, 0.3f, 0.3f);

    private void Start()
    {
        dialogueBubble.transform.localScale = Vector3.zero;
        dialogueBubble.transform.rotation = Camera.main.transform.rotation;
        ShowBubble();
    }

    private void Update()
    {

        timer += Time.deltaTime;

        if (timer >= timePerDialogue)
        {
            if (isFirstCharaTurn)
            {
                ShowBubble();
                otherDialogue.HideBubble();
            }
            else
            {
                otherDialogue.ShowBubble();
                HideBubble();
            }
            timer = 0f;
            isFirstCharaTurn = !isFirstCharaTurn;

        }
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
