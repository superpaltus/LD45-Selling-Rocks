using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeBehaviour : MonoBehaviour
{
    bool m_isStopped;

    void Update()
    {
        if (!m_isStopped)
        {
            var translation = (Vector3.zero - transform.position) * Time.deltaTime / 10f;
            transform.Translate(translation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        m_isStopped = true;
        transform.GetChild(0).GetComponent<Rotator>().enabled = false;

    }
}
