using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LuksoTimer : MonoBehaviour
{

    private Rigidbody2D rb;
    private RectTransform rt;
    private Animator anim;

    private AudioSource asource;
    public AudioClip breakSFX;

    public float speed;
    private bool speedChanged;

    private bool broke;
    public float brokeTime;

    public GameObject juan;
    private LuksoJuan juanScript;
    private Rigidbody2D juanRB;

    private int touching;

    public GameObject meter;

    public GameObject canvas;
    public GameObject[] FXs;
    private GameObject chosenFX;
    public GameObject pulseFX;
    public GameObject bgPulse;

    public AudioClip YellowSFX;
    public AudioClip OrangeSFX;
    public AudioClip RedSFX;
    private AudioClip chosenSFX;

    public int timerHitsReq;
    public int timerHits;

    public static float points;

    void Start()
    {

        points = 0;

        rb = GetComponent<Rigidbody2D>();
        rt = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();
        asource = GetComponent<AudioSource>();

        if (juan != null) juanScript = juan.GetComponent<LuksoJuan>();
        if (juan != null) juanRB = juan.GetComponent<Rigidbody2D>();

        speedChanged = false;

    }

    private void Update()
    {

        anim.SetBool("Broke", broke);

        if ((Input.GetKeyDown(KeyCode.Space) &&
            Time.timeScale != 0 ||
            (Input.GetMouseButtonDown(0)) && !MouseDetector.mouseDetected) &&
            touching > 0 &&
            !broke &&
            Time.timeScale != 0)
        {
            asource.PlayOneShot(chosenSFX);

            var FX = Instantiate(chosenFX) as GameObject;
            FX.transform.SetParent(canvas.transform, false);
            FX.transform.position = transform.position;

            var PFX = Instantiate(pulseFX) as GameObject;
            PFX.transform.SetParent(canvas.transform, false);
            if (bgPulse == null) PFX.transform.localPosition = new Vector2(0, 78);
            else PFX.transform.localPosition = new Vector2(0, -72);
            if (bgPulse != null) StartCoroutine(BGPulse());

            if (chosenFX == FXs[2])
            {
                points += 1;
            }
            else if (chosenFX == FXs[1])
            {
                points += 2;
            }
            else if (chosenFX == FXs[0])
            {
                points += 3;
            }
        }
        else if ((Input.GetKeyDown(KeyCode.Space) &&
            Time.timeScale != 0 ||
            (Input.GetMouseButtonDown(0)) && !MouseDetector.mouseDetected) &&
            touching <= 0 &&
            !broke &&
            Time.timeScale != 0)
        {
            StartCoroutine(Break());
        }

        if (rt.localPosition.x >= 146 && !speedChanged)
        {
            speed *= -1;
            speedChanged = true;
        }
        if (rt.localPosition.x <= -146.25 && speedChanged)
        {
            speed *= -1;
            speedChanged = false;
        }


    }

    void FixedUpdate()
    {
        rt.localPosition = new Vector2(rt.localPosition.x + speed, rt.localPosition.y);
    }

    IEnumerator Break()
    {

        asource.PlayOneShot(breakSFX);

        broke = true;
        meter.transform.localPosition = new Vector2(2, meter.transform.localPosition.y);
        yield return new WaitForSeconds(brokeTime / 4);
        meter.transform.localPosition = new Vector2(-2, meter.transform.localPosition.y);
        yield return new WaitForSeconds(brokeTime / 4);
        meter.transform.localPosition = new Vector2(2, meter.transform.localPosition.y);
        yield return new WaitForSeconds(brokeTime / 4);
        meter.transform.localPosition = new Vector2(-2, meter.transform.localPosition.y);
        yield return new WaitForSeconds(brokeTime / 4);
        meter.transform.localPosition = new Vector2(0, meter.transform.localPosition.y);
        broke = false;
    }

    IEnumerator BGPulse()
    {
        float timeElapsed = 0;

        Color temp = bgPulse.GetComponent<SpriteRenderer>().color;

        bgPulse.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

        while (timeElapsed < .45f)
        {
            temp.r = Mathf.Lerp(255f / 255f, 150f / 255f, timeElapsed / .45f);
            temp.g = Mathf.Lerp(255f / 255f, 150f / 255f, timeElapsed / .45f);
            temp.b = Mathf.Lerp(255f / 255f, 150f / 255f, timeElapsed / .45f);
            bgPulse.GetComponent<SpriteRenderer>().color = new Color(temp.r, temp.g, temp.b, 255);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        // valueToLerp = endValue;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Lukso Meter"))
        {
            timerHits++;
            if (timerHits % 4 == 1 && timerHits < timerHitsReq && juan != null)
            {

                juanRB.AddForce(Vector2.right * juanScript.intSpeed * 4);

                if (!juanScript.moved)
                {
                    juanScript.moved = true;
                }
                else if (juanScript.moved)
                {
                    juanScript.moved = false;
                }
            }
        }

        if (col.gameObject.CompareTag("Red Spot"))
        {
            touching++;
            chosenFX = FXs[0];
            chosenSFX = RedSFX;
        }
        else if (col.gameObject.CompareTag("Orange Spot"))
        {
            touching++;
            chosenFX = FXs[1];
            chosenSFX = OrangeSFX;
        }
        else if (col.gameObject.CompareTag("Yellow Spot"))
        {
            touching++;
            chosenFX = FXs[2];
            chosenSFX = YellowSFX;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Red Spot") ||
            col.gameObject.CompareTag("Orange Spot") ||
            col.gameObject.CompareTag("Yellow Spot")) touching--;
    }

}
