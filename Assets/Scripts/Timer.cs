using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text clockText;

    public float minut, second1, second2;
    
    void Start()
    {
        clockText = GetComponent<Text>();

        minut = 5f;
        second2 = 60f;
    }

    
    void Update()
    {
        second2 -= 1f * Time.deltaTime;

        if (second2 < 10f)
        {
            minut -= 1f;
            second2 = 60f;
        }

        clockText.text = minut.ToString("F0") + ":" + second2.ToString("F0");
    }
}
