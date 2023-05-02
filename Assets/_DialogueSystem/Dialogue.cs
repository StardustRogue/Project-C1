using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string _name;

    [TextArea(1, 10)]
    public string[] _sentences;
}
