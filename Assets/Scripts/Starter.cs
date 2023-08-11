using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{

    public AudioSource BGM;

    public GameObject hotspotSpawner;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Lukso Timer"))
        {
            BGM.Play();
            hotspotSpawner.SetActive(true);
        }
        Destroy(gameObject);
    }
}
