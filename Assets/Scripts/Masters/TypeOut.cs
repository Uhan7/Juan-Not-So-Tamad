using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeOut : MonoBehaviour
{

    public TextMeshProUGUI paperText;
    [TextArea(8, 10)]
    public string textToType;

    public AudioSource asource;

    void OnEnable()
    {
        paperText.text = "";
        StartCoroutine(TypeText(textToType));
    }

    IEnumerator TypeText(string text)
    {
        foreach (char letter in text)
        {
            paperText.text += letter;
            asource.Play();
            if (letter == ':' ||
                letter == '"') yield return new WaitForSeconds(.16f);
            else if (letter == ' ') yield return null;
            else yield return new WaitForSeconds(.04f);

        }
    }

    public void Finish()
    {
        StopAllCoroutines();
        paperText.text = textToType;
    }
}
