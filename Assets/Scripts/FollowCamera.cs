using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public float smooth = 5f;

    public Vector3 offset = new Vector3(5f, 5f, -11f);

    public static FollowCamera Singleton;

    private void Start()
    {
        Singleton = this;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth);
    }
}
