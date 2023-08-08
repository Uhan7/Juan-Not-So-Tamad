using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuksoTimer : MonoBehaviour
{

    private Rigidbody2D rb;
    private RectTransform rt;

    public float speed;
    private bool speedChanged;

    public GameObject RedFX;

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
            Instantiate(RedFX, new Vector2 = (rt.position.x, rt.position.y));
        }

    }

    void FixedUpdate()
    {
        rb.velocity = (Vector2.right * speed);
    }
}
