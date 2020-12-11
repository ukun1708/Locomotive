using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PathMover : MonoBehaviour
{
    public float speed = 1f;

    public float m_Position;

    public CinemachinePathBase.PositionUnits m_PositionUnits = CinemachinePathBase.PositionUnits.Distance;

    public CinemachineSmoothPath m_Path;

    [HideInInspector]
    public bool play = true;

    public static PathMover Singleton;

    public float puthLVL;

    void Start()
    {
        Singleton = this;
        play = true;

        puthLVL = 0f;
    }


    void Update()
    {

        if (play == true)
        {
            if (Input.GetMouseButton(0))
            {
                puthLVL = m_Position + speed * Time.deltaTime * 5f;

                SetCartPosition(puthLVL);

                //TextScaler.Singleton.gameObject.SetActive(false);
            }
        }


    }

    void SetCartPosition(float distanceAlongPath)
    {
        if (m_Path != null)
        {
            m_Position = m_Path.StandardizeUnit(distanceAlongPath, m_PositionUnits);
            Vector3 pos = m_Path.EvaluatePositionAtUnit(m_Position, m_PositionUnits);
            transform.position = new Vector3(pos.x, pos.y, pos.z);

            //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, m_Path.EvaluateOrientationAtUnit(m_Position, m_PositionUnits).eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = m_Path.EvaluateOrientationAtUnit(m_Position, m_PositionUnits);
        }
    }
}
