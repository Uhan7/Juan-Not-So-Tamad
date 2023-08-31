using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;
    private Animator anim;

    private AudioSource asource;
    private AudioClip voice;

    public TextMeshProUGUI nametext;
    public TextMeshProUGUI nametextShadow;
    public Image charaFace;
    public TextMeshProUGUI dialogueText;

    public static bool openWindow;

    public float normalTalkingSpeed;
    public float pausesSpeed;
    public float periodSpeed;

    private bool skipSentence;
    public GameObject skipButton;

    private void Start()
    {
        asource = GetComponent<AudioSource>();
        sentences = new Queue<string>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("Open Window", openWindow);
    }


    public void StartDialogue(Dialogue dialogue)
    {

        nametext.text = dialogue.name;
        nametextShadow.text = dialogue.name;
        if (dialogue.flipFace) charaFace.rectTransform.localScale = new Vector3(-1, 1, 1);
        else charaFace.rectTransform.localScale = new Vector3(1, 1, 1);
        charaFace.sprite = dialogue.faceSprite;
        voice = dialogue.voice;

        openWindow = true;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        skipButton.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    public void SkipSentence()
    {
        skipSentence = true;
        skipButton.SetActive(false);
    }

    IEnumerator TypeSentence(string sentence)
    {
        yield return new WaitForSeconds(0.15f);
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            if (!skipSentence && dialogueText.text != sentence)
            {
                asource.PlayOneShot(voice);
                dialogueText.text += letter;
                yield return new WaitForSeconds(normalTalkingSpeed);
                if (letter == ',' ||
                    letter == '/' ||
                    letter == ';' ||
                    letter == ':' ||
                    letter == '"' ||
                    letter == '(' ||
                    letter == ')') yield return new WaitForSeconds(pausesSpeed);
                if (letter == '.' ||
                    letter == '?' ||
                    letter == '!') yield return new WaitForSeconds(periodSpeed);
            }
            if (skipSentence || dialogueText.text == sentence)
            {
                skipButton.SetActive(false);
                skipSentence = false;
                dialogueText.text = "";
                dialogueText.text = sentence;
            }
        }
    }

    public void EndDialogue()
    {
        print("boink");
        openWindow = false;
    }

}
