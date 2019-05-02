using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManipulator : MonoBehaviour
{
    TextMesh Text;
    
    //TODO muligvis bedre metode med en singleton

    private void Start()
    {
        Text = GetComponent<TextMesh>();
    }

    // public string textTochange;

    //void Update()
    //{
    //    Text.text = textTochange;
    //}

    public void TextUpdate(string textToChange)
    {
        Text.text = textToChange;
    }
}
