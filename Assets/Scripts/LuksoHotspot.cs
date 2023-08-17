using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuksoHotspot : MonoBehaviour
{

    private bool touching;
    public GameObject hitbox;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (touching)
            {
                hitbox.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Lukso Timer"))
        {
            touching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Lukso Timer"))
        {
            hitbox.SetActive(false);
            Destroy(gameObject);
        }
    }

}
