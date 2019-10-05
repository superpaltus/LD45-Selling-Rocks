using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Transform m_myTransform;
    [SerializeField]
    private float m_speed = 10f;

    void Start()
    {
        m_myTransform = transform;
    }

    void Update()
    {
        float x = 1f;//Random.Range(-1f, 1f);
        float y = 0f;
        float z = 1f;
        m_myTransform.Rotate(new Vector3(x,y,z) * Time.deltaTime * m_speed);
    }
}
