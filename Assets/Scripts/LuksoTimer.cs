using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuksoTimer : MonoBehaviour
{

    private Rigidbody2D rb;
    private RectTransform rt;

    public float speed;
    private bool speedChanged;

    public GameObject canvas;
    public GameObject[] FXs;
    public GameObject chosenFX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rt = GetComponent<RectTransform>();

        speedChanged = false;
    }

    private void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.W))
        {
            var FX = Instantiate(chosenFX) as GameObject;
            FX.transform.SetParent(canvas.transform, false);
            FX.transform.position = transform.position;
        }

    }

    void FixedUpdate()
    {
        rb.velocity = (Vector2.right * speed);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
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
        else
        {
            print("nah");
        }
    }
}
