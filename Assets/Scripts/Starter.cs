using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{

    public AudioSource BGM;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Lukso Timer")) BGM.Play();
        Destroy(gameObject);
    }
}
