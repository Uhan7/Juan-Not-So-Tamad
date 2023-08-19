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

    void Start()
    {
        luksoTimerScript = luksoTimer.GetComponent<LuksoTimer>();
        asource = GetComponent<AudioSource>();
        StartCoroutine(StartBeep());
    }

    void Update()
    {
        if (luksoTimerScript.timerHits >= luksoTimerScript.timerHitsReq)
        {
            if (luksoTimerScript.points >= reqPoints)
            {
                print("you passed yey bitch");
            }
            else
            {
                print("nah");
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
