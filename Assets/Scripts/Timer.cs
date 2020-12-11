using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text clockText;

    public float minut, second;
    
    void Start()
    {
        clockText = GetComponent<Text>();

        minut = 5f;
        second = 60f;
    }

    
    void Update()
    {
        second -= 1f * Time.deltaTime;

        if (second < 1f)
        {
            minut -= 1f;
            second = 60f;
        }

        clockText.text = minut.ToString("F0") + ":" + second.ToString("F0");
    }
}
