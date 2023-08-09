using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuksoTimer : MonoBehaviour
{

    private Rigidbody2D rb;
    private RectTransform rt;
    private Animator anim;

    public float speed;
    private bool speedChanged;

    private bool broke;
    public float brokeTime;

    private int touching;

    public GameObject canvas;
    public GameObject[] FXs;
    public GameObject chosenFX;
    public GameObject pulseFX;
    public GameObject breakFX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rt = GetComponent<RectTransform>();
        anim = GetComponent<Animator>();

        speedChanged = false;

    }

    private void Update()
    {

        anim.SetBool("Broke", broke);

        if (rt.localPosition.x >= 146 && !speedChanged)
        {
            speed *= -1;
            speedChanged = true;
        }
        if (rt.localPosition.x <= -146 && speedChanged)
        {
            speed *= -1;
            speedChanged = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && touching > 0 && !broke)
        {
            var FX = Instantiate(chosenFX) as GameObject;
            FX.transform.SetParent(canvas.transform, false);
            FX.transform.position = transform.position;

            var PFX = Instantiate(pulseFX) as GameObject;
            PFX.transform.SetParent(canvas.transform, false);
            PFX.transform.position = new Vector2(160, transform.position.y);
        }
        else if (Input.GetKeyDown(KeyCode.W) && touching <= 0)
        {
            StartCoroutine(Break());
        }

    }

    IEnumerator Break()
    {
        broke = true;

        var BFX = Instantiate(breakFX) as GameObject;
        BFX.transform.SetParent(canvas.transform, false);
        BFX.transform.position = transform.position;

        yield return new WaitForSeconds(brokeTime);
        broke = false;
    }

    void FixedUpdate()
    {
        rb.velocity = (Vector2.right * speed);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        touching++;

        if (col.gameObject.CompareTag("Red Spot"))
        {
            chosenFX = FXs[0];
        }
        else if (col.gameObject.CompareTag("Orange Spot"))
        {
            chosenFX = FXs[1];
        }
        else if (col.gameObject.CompareTag("Yellow Spot"))
        {
            chosenFX = FXs[2];
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        touching--;
    }
}
