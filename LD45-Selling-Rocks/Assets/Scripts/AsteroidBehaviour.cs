using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private float m_speed = 10f;

    private int m_temperatureChange;
    private int m_waterChange;
    private int m_oxygenChange;
    private int m_pressureChange;

    private void Start()
    {
        m_temperatureChange = Random.Range(-30, 31);
        m_waterChange = Random.Range(-3000, 3001);
        m_oxygenChange = Random.Range(-15, 16);
        m_pressureChange = Random.Range(-300, 301);
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
