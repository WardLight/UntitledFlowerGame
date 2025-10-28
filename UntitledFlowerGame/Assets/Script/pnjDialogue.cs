using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pnjDialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject dialogueBubble;
    [SerializeField]
    private TextMesh dialogueMesh;
    [SerializeField]
    private float timePerDialogue;
    [SerializeField]
    private List<string> dialogues;


    private float timer;
    private int currentDialogueIndex = 0;

    private void Start()
    {
        dialogueBubble.transform.LookAt(Camera.main.transform);
        dialogueBubble.transform.Rotate(0, 180, 0);

        dialogueMesh.text = dialogues[currentDialogueIndex];
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timePerDialogue)
        {
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
