using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueScene : MonoBehaviour {
    
    public Dialogue[] dialogues;
    int dialogueIndex = 0;

    private void Start()
    {
        ShowNextDialogue();
    }

    void ShowNextDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogues[dialogueIndex]);
        dialogueIndex++;
    }

    private void Update()
    {
        if (!DialogueManager.Instance.dialogueInProgress)
        {
            if (dialogueIndex < dialogues.Length)
                ShowNextDialogue();
            else
                SceneManager.LoadScene("Castle");
        }
    }
}
