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

        flashed = false;
    }

    private void Update()
    {
        fillBar.fillAmount = timerScript.points / maxPoints;

        if (fillBar.fillAmount >= 1 && !flashed)
        {
            StartCoroutine(BarFlash());
            flashed = true;
        }

    }

    IEnumerator BarFlash()
    {
        barFlasher.SetActive(true);
        yield return new WaitForSeconds(flashRate);
        barFlasher.SetActive(false);
        yield return new WaitForSeconds(flashRate);
        barFlasher.SetActive(true);
        yield return new WaitForSeconds(flashRate);
        barFlasher.SetActive(false);
        yield return new WaitForSeconds(flashRate);
        barFlasher.SetActive(true);
        yield return new WaitForSeconds(flashRate);
        barFlasher.SetActive(false);
        yield return new WaitForSeconds(flashRate);
        barFlasher.SetActive(true);
        yield return new WaitForSeconds(flashRate);
        barFlasher.SetActive(false);
        yield return new WaitForSeconds(flashRate);
        barFlasher.SetActive(true);
    }

}