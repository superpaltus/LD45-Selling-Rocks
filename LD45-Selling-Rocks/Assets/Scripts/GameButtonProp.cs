using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonProp : MonoBehaviour
{
    [SerializeField] private int m_tChange;
    [SerializeField] private int m_h20Change;
    [SerializeField] private int m_o2Change;
    [SerializeField] private int m_pChange;
    [SerializeField] private int m_energyPrice;

    private int multiplexor = 1;

    public void OnButtonPressed()
    {
        do { multiplexor = Random.Range(-3, 4); }
        while (multiplexor == 0);
        print("multiplexor is : " + multiplexor);

        if (GameManagerProp.instance.EnoughEnergy(m_energyPrice))
        {
            GameManagerProp.instance.energy -= m_energyPrice;
            GameManagerProp.instance.temperature = Mathf.Clamp(GameManagerProp.instance.temperature += m_tChange * multiplexor, 0, 200);
            GameManagerProp.instance.water = Mathf.Clamp(GameManagerProp.instance.water += m_h20Change * multiplexor, 0, 10000);
            GameManagerProp.instance.oxygen = Mathf.Clamp(GameManagerProp.instance.oxygen += m_o2Change * multiplexor, 0, 100);
            GameManagerProp.instance.pressure = Mathf.Clamp(GameManagerProp.instance.pressure += m_pChange * multiplexor, 0, 2000);

            GameManagerProp.instance.CreateProbe();
            TopButtons.instance.ResetButtons();
        }
    }
}
