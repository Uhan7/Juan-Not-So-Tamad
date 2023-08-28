using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    public bool trigger;
    public bool collide;

    public bool destroyAfterTouch;
    public bool destroyAfterTalk;
    public bool destroySomethingAfterTalk;
    private bool canWaitAfterTalk;
    public bool startOtherDialogueAfterTalk;
    public bool doGoNext;
    public GameObject otherDialogueTrigger;
    public GameObject somethingToDestroy;
    public float waitTime;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void Update()
    {
        if (DialogueManager.openWindow)
        {
            canWaitAfterTalk = true;
        }

        if (canWaitAfterTalk && !DialogueManager.openWindow)
        {
            if (startOtherDialogueAfterTalk) StartCoroutine(StartOtherDialogue());
            if (destroySomethingAfterTalk) Destroy(somethingToDestroy, waitTime);
            if (destroyAfterTalk) Destroy(gameObject, waitTime + 0.05f);
            if (doGoNext)GoNext();
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Juan"))
        {
            if (trigger) TriggerDialogue();
            if (destroyAfterTouch) Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Juan"))
        {
            if (collide) TriggerDialogue();
            if (destroyAfterTouch) Destroy(gameObject);
        }
    }

    public void GoNext()
    {
        otherDialogueTrigger.SetActive(true);
    }

    IEnumerator StartOtherDialogue()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        FindObjectOfType<DialogueManager>().StartDialogue(otherDialogueTrigger.GetComponent<DialogueTrigger>().dialogue);
    }

}
