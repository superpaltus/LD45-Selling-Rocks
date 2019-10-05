using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextEditor : MonoBehaviour
{
    [SerializeField]
    private Text txtTime;
    [SerializeField]
    private Text txtEnergy;

    private float m_time;
    private int m_energy;

    public static UITextEditor instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        m_time = 245f;
    }

    private void Update()
    {
        TimeDecrease();
    }

    #region Time
    public void SetTime(float settingValue)
    {
        m_time = settingValue;
        ShowTime(m_time);
    }

    private void TimeDecrease()
    {
        m_time -= Time.deltaTime;
        ShowTime(m_time);
    }

    private void ShowTime(float settingValue)
    {
        int min = (int)(settingValue / 60);
        int sec = (int)settingValue - min * 60;
        txtTime.text = min.ToString("0") + ":" + sec.ToString("00"); 
    }
    #endregion

    #region Energy
    private void PlusEnergy(int plusValue)
    {
        m_energy += plusValue;
    }
    private void MinusEnergy(int minusValue)
    {
        m_energy -= minusValue;
    }
    private bool EnoughEnergy(int neededValue)
    {
        if (m_energy >= neededValue) return true;
        else return false;
    }
    #endregion

}
