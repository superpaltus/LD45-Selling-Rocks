using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private float m_speed = 10f;

    [SerializeField] private int m_temperatureChange = 30;
    [SerializeField] private int m_waterChange = 3000;
    [SerializeField] private int m_oxygenChange = 15;
    [SerializeField] private int m_pressureChange = 300;

    private void Start()
    {
        m_temperatureChange = Random.Range(-m_temperatureChange, 0);
        m_waterChange = Random.Range(-m_waterChange, 0);
        m_oxygenChange = Random.Range(-m_oxygenChange, 0);
        m_pressureChange = Random.Range(-m_pressureChange, 0);
    }

    private void Update()
    {
        var translation = (Vector3.zero - transform.position) * Time.deltaTime * m_speed;
        transform.Translate(translation);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManagerProp.instance.temperature = Mathf.Clamp(GameManagerProp.instance.temperature += m_temperatureChange, 0, 200);
        GameManagerProp.instance.water = Mathf.Clamp(GameManagerProp.instance.water += m_waterChange, 0, 10000);
        GameManagerProp.instance.oxygen = Mathf.Clamp(GameManagerProp.instance.oxygen += m_oxygenChange, 0, 100);
        GameManagerProp.instance.pressure = Mathf.Clamp(GameManagerProp.instance.pressure += m_pressureChange, 0, 2000);

        Destroy(this.gameObject);
    }
}
