using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuanLukso : MonoBehaviour
{

    private Rigidbody2D rb;

    private AudioSource asource;
    public AudioClip winSFX;
    public AudioClip loseSFX;

    public float intSpeed;
    public float endSpeed;
    public float jumpHeight;

    public KeyCode jumpKey;
    private bool jumpPress;

    public float decaySpeed;

    public float slowTimeScale;
    public float waitTime1;
    public float waitTime2;

    private bool endRun;
    private bool roundEnd;
    private bool endDecaySpeed;

    public GameObject gameOverScreen;

    void Start()
    {

        roundEnd = false;

        rb = GetComponent<Rigidbody2D>();
        asource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            jumpPress = true;
        }

        if (LuksoGameMaster.wonRound == 2 && !roundEnd)
        {
            StartCoroutine(RoundEnd(true));
            roundEnd = true;
        }
        else if (LuksoGameMaster.wonRound == 1 && !roundEnd){
            StartCoroutine(RoundEnd(false));
            roundEnd = true;
        }

    }

    void FixedUpdate()
    {
        if (LuksoGameMaster.wonRound == 0 || endDecaySpeed) rb.velocity = new Vector2(rb.velocity.x * decaySpeed, rb.velocity.y);
        if (endRun) rb.velocity = new Vector2(endSpeed, rb.velocity.y);
    }

    IEnumerator RoundEnd(bool win)
    {
        Time.timeScale = slowTimeScale;
        if (win) rb.AddForce(Vector2.up * jumpHeight * LuksoTimer.points);
        else if (!win)
        {
            rb.AddForce(Vector2.up * jumpHeight * LuksoTimer.points * 0.8f); 
        }
        endRun = true;
        yield return new WaitForSecondsRealtime(waitTime1);
        endRun = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(waitTime2);
        endDecaySpeed = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Baka"))
        {
            StartCoroutine(ActivateGameOverScreen());
        }
    }

    IEnumerator ActivateGameOverScreen()
    {
        yield return new WaitForSecondsRealtime(2f);
        asource.PlayOneShot(loseSFX);
        gameOverScreen.SetActive(true);
    }

}
