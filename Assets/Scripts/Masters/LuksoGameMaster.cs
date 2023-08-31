using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LuksoGameMaster : MonoBehaviour
{

    public GameObject luksoTimer;
    private LuksoTimer luksoTimerScript;

    private bool hideMeter;
    public GameObject meter;

    public int reqPoints;

    private AudioSource asource;
    public AudioClip beep;

    public float waitTime;

    public static int wonRound;
    public bool roundEnd;

    public GameObject blackscreen;

    void Start()
    {

        wonRound = 0;
        roundEnd = false;

        luksoTimerScript = luksoTimer.GetComponent<LuksoTimer>();
        asource = GetComponent<AudioSource>();
        Time.timeScale = 0;
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

            StartCoroutine(HideMeter());

        }
    }

    private void FixedUpdate()
    {
        if (hideMeter) meter.transform.localPosition = new Vector2(0, meter.transform.localPosition.y - 3);
    }

    IEnumerator StartBeep()
    {
        yield return new WaitForSecondsRealtime(1f);
        asource.PlayOneShot(beep);
        yield return new WaitForSecondsRealtime(waitTime);
        luksoTimer.SetActive(true);
        Time.timeScale = 1;
    }

    IEnumerator HideMeter()
    {
        yield return new WaitForSecondsRealtime(.25f);
        hideMeter = true;
        yield return new WaitForSecondsRealtime(2f);
        hideMeter = false;
        Destroy(meter);
    }

    public void Invoker(string funcName)
    {
        blackscreen.SetActive(true);
        Invoke(funcName, 3.5f);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
