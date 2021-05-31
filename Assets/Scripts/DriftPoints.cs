using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DriftPoints : MonoBehaviour
{
    public static float driftPointHolder;
    public Text text;
    public static bool isShaking = false;
    public Animator anim;
    void Start()
    {
        
    }

    void Update()
    {
        text.text = ((int)driftPointHolder).ToString();
        if (isShaking)
        {
            anim.SetBool("isShaking", true);
        } else
        {
            anim.SetBool("isShaking", false);
        }
    }
}
