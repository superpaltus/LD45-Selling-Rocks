using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Transform m_myTransform;
    [SerializeField]
    private float m_speed = 10f;
    [SerializeField]
    private bool m_planetAnchor;
    [SerializeField]
    private bool m_OSS;
    [SerializeField]
    private bool m_Probe;

    void Start()
    {
        m_myTransform = transform;
    }

    void Update()
    {
        if (m_planetAnchor)
        {
            float x = 1f;//Random.Range(-1f, 1f);
            float y = 0f;
            float z = 1f;
            m_myTransform.Rotate(new Vector3(x, y, z) * Time.deltaTime * m_speed);
        }
        else if (m_OSS)
        {
            m_myTransform.Rotate(new Vector3(0f, 1f, 0f) * Time.deltaTime * m_speed);
        }
        else if(m_Probe)
        {
            m_myTransform.Rotate(new Vector3(0f, 0f, 1f) * Time.deltaTime * m_speed);
        }
    }
}
