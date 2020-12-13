using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    Camera camera;

    public GameObject camera2;
    void Start()
    {
        camera = GetComponent<Camera>();

        camera.enabled = true;
        camera2.SetActive(false);
    }

    public void Switch()
    {
        if (camera.enabled == true)
        {
            camera.enabled = false;

            camera2.SetActive(true);
        }
        else
        {
            camera.enabled = true;

            camera2.SetActive(false);
        }
    }
}
