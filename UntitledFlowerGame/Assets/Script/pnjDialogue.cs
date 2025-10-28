using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pnjDialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBubble;
    [SerializeField]
    private TextMeshPro dialogueMesh;
    [SerializeField]
    private float timePerDialogue;
    [SerializeField]
    public List<string> dialogues;
    [SerializeField]
    private bool isLinked;
    [SerializeField]
    private bool isFirst;
    [SerializeField]
    private GameObject otherPnj; 

    private float timer;
    private int currentDialogueIndex = 0;

    private bool isFistShown = true;
    private int otherCurrentDialogueIndex = 0;

    private void Start()
    {
        dialogueBubble.transform.rotation = Camera.main.transform.rotation;
        
        if (isLinked)
        {
            if (isFirst)
            {
                dialogueMesh.text = dialogues[currentDialogueIndex];
            }
        }
        else
        {

            dialogueMesh.text = dialogues[currentDialogueIndex];
        }
    }
    void Update()
    {

        if (isLinked)
        {
            if (isFirst)
            {
                timer += Time.deltaTime;
                pnjDialogue otherDialogueScript = otherPnj.GetComponent<pnjDialogue>();

                if (timer > timePerDialogue)
                {
                    timer = 0;
                    if (isFistShown)
                    {
                        if (currentDialogueIndex < dialogues.Count - 1)
                        {
                            currentDialogueIndex++;
                        }
                        else
                        {
                            currentDialogueIndex = 0;
                        }
                        dialogueMesh.text = dialogues[currentDialogueIndex];
                        isFistShown = false;
                    }
                    else
                    {
                        if (otherCurrentDialogueIndex < otherDialogueScript.dialogues.Count - 1)
                        {
                            otherCurrentDialogueIndex++;
                        }
                        else
                        {
                            otherCurrentDialogueIndex = 0;
                        }
                        otherDialogueScript.dialogueMesh.text = otherDialogueScript.dialogues[otherCurrentDialogueIndex];
                        isFistShown = true;
                    }
                }
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > timePerDialogue)
            {
                StartCoroutine(HideBubble());
                timer = 0;
                if (currentDialogueIndex < dialogues.Count - 1)
                {
                    currentDialogueIndex++;
                }
                else
                {
                    currentDialogueIndex = 0;
                }
                dialogueMesh.text = dialogues[currentDialogueIndex];
            }
        }
    }

    IEnumerator ShowBubble()
    {
        float timerTransition = 0f;
        while (timerTransition < 0.3f)
        {
            dialogueBubble.transform.localScale = new Vector3(timerTransition, timerTransition, timerTransition);

            timerTransition += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator HideBubble()
    {
        float timerTransition = 0.3f;
        while (timerTransition > 0f)
        {
            dialogueBubble.transform.localScale = new Vector3(timerTransition, timerTransition, timerTransition);

            timerTransition -= Time.deltaTime;
            yield return null;
        }
        print("show");
        StartCoroutine(ShowBubble());
    }
}