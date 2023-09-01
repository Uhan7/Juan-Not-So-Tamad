using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralSceneTransitions : MonoBehaviour
{

    private AudioSource asource;
    public AudioClip soundToPlay;

    public GameObject blackscreen;

    public bool quickie;

    public bool trigger;
    public bool collide;

    public bool playSound;

    public AudioSource otherASource;
    public bool shutUpSound;

    public string nameOfToucher;

    public string sceneToGo;

    private void Start()
    {
        asource = GetComponent<AudioSource>();
    }

    public void Waiter(string sceneName)
    {
        if (blackscreen != null) blackscreen.SetActive(true);
        if (playSound) asource.PlayOneShot(soundToPlay);
        if (shutUpSound) otherASource.Stop();
        StartCoroutine(GoToScene(sceneName));
    }

    IEnumerator GoToScene(string sceneName)
    {
        if (quickie) yield return new WaitForSecondsRealtime(1f);
        else yield return new WaitForSecondsRealtime(4f);
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (trigger && col.gameObject.name == nameOfToucher) Waiter(sceneToGo);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (collide && col.gameObject.name == nameOfToucher) Waiter(sceneToGo);
    }

}
