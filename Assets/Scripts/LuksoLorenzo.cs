using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuksoLorenzo : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource asource;

    public float jumpHeight;

    private bool run;
    private bool decay;

    public float runSpeed;
    public float timeTillJump;
    public float timeTillDecaySpeed;
    public float decaySpeed;

    public GameObject dialogueToActivate;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        asource = GetComponent<AudioSource>();
        StartCoroutine(LuksoScene());
    }

    void FixedUpdate()
    {
        if (run) rb.velocity = new Vector2 (runSpeed, rb.velocity.y);
        if (decay) rb.velocity = new Vector2(rb.velocity.x * decaySpeed, rb.velocity.y);
    }

    IEnumerator LuksoScene()
    {
        yield return new WaitForSeconds(2f);
        run = true;
        yield return new WaitForSeconds(timeTillJump);
        rb.AddForce(Vector2.up * jumpHeight);
        yield return new WaitForSeconds(timeTillDecaySpeed);
        run = false;
        decay = true;
        yield return new WaitForSeconds(.4f);
        transform.localScale = new Vector3(-1, 1, 1);
        yield return new WaitForSeconds(.1f);
        dialogueToActivate.SetActive(true);
    }

}
