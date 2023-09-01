using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuksoJuan : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    private AudioSource asource;

    public AudioClip landSFX;
    public AudioClip hitSFX;
    public AudioClip loseJingle;
    public AudioClip jumpSFX;

    public float intSpeed;
    public float endSpeed;
    public float jumpHeight;

    public float decaySpeed;

    public float slowTimeScale;
    public float waitTime1;
    public float waitTime2;

    private bool endRun;
    private bool roundEnd;
    private bool endDecaySpeed;

    public bool moved;
    private bool roundLost;
    private bool roundWon;

    public GameObject backgroundNormal;

    public GameObject gameOverScreen;

    public GameObject cam1;
    public GameObject cam2;

    public GameObject lorenzo;

    void Start()
    {

        roundEnd = false;
        moved = false;

        roundLost = false;
        roundWon = false;

        rb = GetComponent<Rigidbody2D>();
        asource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {

        anim.SetFloat("Speed", rb.velocity.x);
        anim.SetBool("Moved", moved);
        anim.SetFloat("Height", rb.velocity.y);
        anim.SetBool("Round Lost", roundLost);

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
        backgroundNormal.SetActive(true);
        asource.PlayOneShot(jumpSFX);
        if (win) rb.AddForce( (Vector2.up * jumpHeight) + Vector2.up * jumpHeight * LuksoTimer.points);
        else if (!win)
        {
            rb.AddForce((Vector2.up * jumpHeight * 5) + (Vector2.up *jumpHeight * LuksoTimer.points * 0.7f)); 
        }
        endRun = true;
        yield return new WaitForSecondsRealtime(waitTime1);
        endRun = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(waitTime2);
        endDecaySpeed = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Baka") && !roundLost)
        {
            asource.PlayOneShot(hitSFX);
            StartCoroutine(ActivateGameOverScreen());
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            roundLost = true;
        }

        else if (col.gameObject.CompareTag("Win Zone") && !roundWon && !roundLost)
        {
            anim.SetTrigger("Win Zoned");
            asource.PlayOneShot(landSFX);
            roundWon = true;
            StartCoroutine(LorenzoTurn());
        }

    }

    IEnumerator ActivateGameOverScreen()
    {
        yield return new WaitForSecondsRealtime(1.25f);
        asource.PlayOneShot(loseJingle);
        gameOverScreen.SetActive(true);
    }

    IEnumerator LorenzoTurn()
    {
        yield return new WaitForSecondsRealtime(1.25f);
        if (!roundLost)
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            lorenzo.SetActive(true);
        }
    }

}
