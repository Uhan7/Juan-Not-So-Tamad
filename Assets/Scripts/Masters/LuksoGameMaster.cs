using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LuksoGameMaster : MonoBehaviour
{

    public GameObject luksoTimer;
    private LuksoTimer luksoTimerScript;

    public int reqPoints;

    private AudioSource asource;
    public AudioClip beep;

    public float waitTime;

    public static int wonRound;
    public bool roundEnd;

    void Start()
    {

        wonRound = 0;
        roundEnd = false;

        luksoTimerScript = luksoTimer.GetComponent<LuksoTimer>();
        asource = GetComponent<AudioSource>();
        StartCoroutine(StartBeep());
    }

    void Update()
    {
        if (luksoTimerScript.timerHits >= luksoTimerScript.timerHitsReq && !roundEnd)
        {
            if (LuksoTimer.points >= reqPoints)
            {
                wonRound = 2;
                roundEnd = true;
            }
            else
            {
                wonRound = 1;
                roundEnd = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator StartBeep()
    {
        asource.PlayOneShot(beep);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(waitTime);
        Time.timeScale = 1;
    }

}
