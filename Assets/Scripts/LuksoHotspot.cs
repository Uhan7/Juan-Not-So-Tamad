using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuksoHotspot : MonoBehaviour
{

    private bool touching;
    public GameObject hitbox;

    public GameObject destroyFX;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (touching)
            {
                KillSelf();
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
            KillSelf();
        }
    }

    private void KillSelf()
    {
        var FX = Instantiate(destroyFX) as GameObject;
        var canvas = GameObject.Find("Canvas");
        FX.transform.SetParent(canvas.transform, false);
        FX.transform.position = transform.position;
        hitbox.SetActive(false);
        Destroy(gameObject);
    }

}
