using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Dialogue
{

    public string name;
    public Sprite faceSprite;

    [TextArea(2, 4)]
    public string[] sentences;

}
