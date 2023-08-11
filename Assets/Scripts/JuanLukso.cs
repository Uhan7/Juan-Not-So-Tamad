using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuanLukso : MonoBehaviour
{

    private Rigidbody2D rb;

    public float intSpeed;
    public float jumpHeight;

    public KeyCode jumpKey;
    private bool jumpPress;

    public float decaySpeed;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            jumpPress = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x * decaySpeed, rb.velocity.y);  
    }
}
