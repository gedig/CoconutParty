using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoconutText : MonoBehaviour
{

    private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        CoconutThrower.CoconutUpdate += UpdateUI;
    }

    void UpdateUI(int coconuts)
    {
        _text.text = "x" + coconuts;
    }
}
