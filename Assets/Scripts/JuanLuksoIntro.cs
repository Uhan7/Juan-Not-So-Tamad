using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuanLuksoIntro : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource asource;
    private Animator anim;

    public float speed;

    public AudioClip walk1SFX;
    public AudioClip walk2SFX;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        asource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("Speed", rb.velocity.x);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void WalkSound1()
    {
        asource.PlayOneShot(walk1SFX);
    }

    public void WalkSound2()
    {
        asource.PlayOneShot(walk2SFX);
    }

}
