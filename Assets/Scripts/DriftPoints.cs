using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftPoints : MonoBehaviour
{
    public static float driftPointHolder;
    public Text text;
    void Start()
    {
        
    }

    void Update()
    {
        text.text = ((int)driftPointHolder).ToString();
    }
}
