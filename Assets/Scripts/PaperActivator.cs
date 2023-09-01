using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperActivator : MonoBehaviour
{

    public GameObject[] paper;

    public void Activate(int paperIndex)
    {
        foreach (GameObject slip in paper)
        {
            if (slip != paper[paperIndex] && GameObject.Find("BTOut") == null) slip.SetActive(false);
        }
        if (GameObject.Find("BTOut") == null) paper[paperIndex].SetActive(true);
    }

}
