using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();

        audio.enabled = false;
    }
    public void SignalOn()
    {
        StartCoroutine(Gudok());
    }

    IEnumerator Gudok()
    {
        audio.enabled = true;

        yield return new WaitForSeconds(2);

        audio.enabled = false;

        yield return null;
    }
}
