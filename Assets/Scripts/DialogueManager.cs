using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager Instance;

    Queue<Sentence> sentences = new Queue<Sentence>();
    Queue<Dialogue> dialogues = new Queue<Dialogue>();

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public bool dialogueInProgress = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void StartDialogues(Dialogue[] _dialogues)
    {
        if (!dialogueInProgress)
        {
            dialogues.Clear();

            foreach (Dialogue d in _dialogues)
            {
                dialogues.Enqueue(d);
            }

            StartDialogue(dialogues.Dequeue());
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueInProgress = true;
        sentences.Clear();
        nameText.text = dialogue.Name;

        animator.SetBool("IsOpen", true);

        foreach (Sentence sentence in dialogue.Sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplaySentence();
    }

    public void DisplaySentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        Sentence sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(DisplayPhrases(sentence));
    }

    IEnumerator DisplayPhrases(Sentence sentence)
    {
        dialogueText.text = "";
        foreach (Phrase phrase in sentence.Phrases)
        {
            yield return StartCoroutine(DisplayPhrase(phrase));
        }

    }

    IEnumerator DisplayPhrase(Phrase phrase)
    {
        foreach (char c in phrase.Content.ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(phrase.ScrollSpeed);
        }

        yield return new WaitForSeconds(phrase.DeliveryTime);
    }

    public void EndDialogue()
    {
        if (dialogues.Count == 0)
        {
            dialogueInProgress = false;
            animator.SetBool("IsOpen", false);
        }
        else
        {
            StartDialogue(dialogues.Dequeue());
        }
    }

    public void EndAllDialogues()
    {
        dialogues.Clear();
        EndDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DisplaySentence();
        }
    }
}
