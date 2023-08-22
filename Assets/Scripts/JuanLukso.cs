using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuanLukso : MonoBehaviour
{

    private Rigidbody2D rb;

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

    void Start()
    {

        roundEnd = false;
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            jumpPress = true;
        }

        if ((LuksoGameMaster.wonRound == 2 || LuksoGameMaster.wonRound == 1) && !roundEnd)
        {
            StartCoroutine(RoundEnd());
            roundEnd = true;
        }

    }

    void FixedUpdate()
    {
        if (LuksoGameMaster.wonRound == 0 || endDecaySpeed) rb.velocity = new Vector2(rb.velocity.x * decaySpeed, rb.velocity.y);
        if (endRun) rb.velocity = new Vector2(endSpeed, rb.velocity.y);
    }

    IEnumerator RoundEnd()
    {
        Time.timeScale = slowTimeScale;
        rb.AddForce(Vector2.up * jumpHeight * LuksoTimer.points);
        endRun = true;
        yield return new WaitForSecondsRealtime(waitTime1);
        endRun = false;
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(waitTime2);
        endDecaySpeed = true;
    }

}
