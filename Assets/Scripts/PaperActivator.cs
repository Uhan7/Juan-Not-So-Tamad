using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperActivator : MonoBehaviour
{

    public GameObject[] paper;

    public void Activate(int paperIndex)
    {
        paper[paperIndex].SetActive(true);
    }

    public void Deactivate(int paperIndex)
    {
        paper[paperIndex].SetActive(false);
    }

}
