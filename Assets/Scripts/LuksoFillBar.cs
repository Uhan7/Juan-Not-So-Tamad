using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuksoFillBar : MonoBehaviour
{

    public Image fillBar;
    public float fillSpeed;

    public GameObject barFlasher;
    public float flashRate;
    private bool flashed;

    public float maxPoints;

    public GameObject timer;
    private LuksoTimer timerScript;

    private void Start()
    {
        timerScript = timer.GetComponent<LuksoTimer>();

        fillBar.fillAmount = 0;

        flashed = false;
    }

    private void Update()
    {
        fillBar.fillAmount = LuksoTimer.points / maxPoints;

        if (fillBar.fillAmount >= 1 && !flashed)
        {
            StartCoroutine(BarFlash());
            flashed = true;
        }

    }

    IEnumerator BarFlash()
    {
        barFlasher.SetActive(true);
        yield return new WaitForSecondsRealtime(flashRate);
        barFlasher.SetActive(false);
        yield return new WaitForSecondsRealtime(flashRate);
        barFlasher.SetActive(true);
        yield return new WaitForSecondsRealtime(flashRate);
        barFlasher.SetActive(false);
        yield return new WaitForSecondsRealtime(flashRate);
        barFlasher.SetActive(true);
        yield return new WaitForSecondsRealtime(flashRate);
        barFlasher.SetActive(false);
        yield return new WaitForSecondsRealtime(flashRate);
        barFlasher.SetActive(true);
        yield return new WaitForSecondsRealtime(flashRate);
        barFlasher.SetActive(false);
        yield return new WaitForSecondsRealtime(flashRate);
        barFlasher.SetActive(true);
    }

}
