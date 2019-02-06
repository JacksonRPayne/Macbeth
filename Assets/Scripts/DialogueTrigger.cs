using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue[] dialogues;
    public bool repeat = false;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogues(dialogues);
        if (!repeat)
            Disable();
    }

    private void EndDialogue()
    {
        DialogueManager.Instance.EndAllDialogues();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            EndDialogue();
        }
    }

    public void Disable()
    {
        GetComponent<Collider>().enabled = false;
    }

}
