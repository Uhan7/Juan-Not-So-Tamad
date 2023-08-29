using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeInto : MonoBehaviour
{

    public float time;
    public float startA;
    public float endA;

    private Color temp;
    private float timeElapsed;

    private void Awake()
    {
        timeElapsed = 0;
        if (GetComponent<Image>() != null) temp = GetComponent<Image>().color;
        else temp = GetComponent<SpriteRenderer>().color;
        temp.a = 0f;
        if (GetComponent<Image>() != null) GetComponent<Image>().color = new Color(temp.r, temp.g, temp.b, startA);
        else GetComponent<SpriteRenderer>().color = new Color(temp.r, temp.g, temp.b, startA);
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if (gameObject.activeInHierarchy)
        {
            temp.a = Mathf.Lerp(startA / 255f, endA / 255f, timeElapsed / time);
            if (GetComponent<Image>() != null) GetComponent<Image>().color = new Color(temp.r, temp.g, temp.b, temp.a);
            else GetComponent<SpriteRenderer>().color = new Color(temp.r, temp.g, temp.b, temp.a);
            timeElapsed += Time.deltaTime;
        }
    }

}
