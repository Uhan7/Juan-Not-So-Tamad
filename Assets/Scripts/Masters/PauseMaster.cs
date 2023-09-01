using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMaster : MonoBehaviour
{

    public GameObject pauseButton;
    public GameObject resumeButton;

    public GameObject pausedScreen;

    private bool paused;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("Paused", paused);
        anim.SetInteger("Round End", LuksoGameMaster.wonRound);
    }

    public void PauseGame()
    {
        if (!paused) paused = true;
        else paused = false;

        if (paused)
        {
            Time.timeScale = 0;
            pausedScreen.SetActive(true);

            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
            pausedScreen.SetActive(false);

            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
        }
    }

}
