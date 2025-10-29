using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class SelfDialogue : MonoBehaviour
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
    private bool isCop;

    private int currentDialogueIndex = 0;
    private float timer = 0f;
    private bool isTransitioning = false;

    private Vector3 targetScale = new Vector3(0.3f, 0.3f, 0.3f);

    private bool isDisable = false;
    

    private void Start()
    {
        dialogueBubble.transform.localScale = Vector3.zero;
        dialogueBubble.transform.rotation = Camera.main.transform.rotation;
        ShowBubble();
    }

    private void Update()
    {
        if (!isDisable)
            if (isTransitioning) return;

            timer += Time.deltaTime;

            if (timer >= timePerDialogue)
            {
                isTransitioning = true;
                HideBubble(() =>
                {
                    ShowBubble();
                    timer = 0f;
                    isTransitioning = false;
                });
            }
        if (isCop)
        {
            isCop = false;
        }
    }

    public void ShowBubble()
    {
        dialogueMesh.text = dialogues[currentDialogueIndex];
        dialogueBubble.transform.DOScale(targetScale, 0.3f);
        currentDialogueIndex = (currentDialogueIndex + 1) % dialogues.Count;
    }

    public void HideBubble(System.Action onComplete)
    {
        dialogueBubble.transform.DOScale(Vector3.zero, 0.3f).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }

    public void HideComplitelyBubble()
    {
        dialogueBubble.SetActive(false);
        isDisable = true;
    }
}