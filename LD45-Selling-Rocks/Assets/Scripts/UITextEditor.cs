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

    private float m_energyTimer;

    public static UITextEditor instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

    }

    private void Update()
    {
        TimeDecrease();
        if (GameManagerProp.instance.energy < 100) EnergyCollect();
    }

    #region Time

    public void SetTime(float settingValue)
    {
        GameManagerProp.instance.time = settingValue;
        ShowTime(GameManagerProp.instance.time);
    }



    private void TimeDecrease()
    {
        GameManagerProp.instance.time -= Time.deltaTime;
        ShowTime(GameManagerProp.instance.time);
    }

    private void ShowTime(float settingValue)
    {
        int min = (int)(settingValue / 60);
        int sec = (int)settingValue - min * 60;
        txtTime.text = min.ToString("0") + ":" + sec.ToString("00"); 
    }
    #endregion

    #region Energy

    public void PlusEnergy(int plusValue)
    {
        GameManagerProp.instance.energy += plusValue;
        ShowEnergy(GameManagerProp.instance.energy);
    }

    public void MinusEnergy(int minusValue)
    {
        GameManagerProp.instance.energy -= minusValue;
        ShowEnergy(GameManagerProp.instance.energy);
    }





    private void EnergyCollect()
    {
        m_energyTimer += Time.deltaTime * GameManagerProp.instance.energyCollectSpeed;
        if (m_energyTimer >= 1f)
        {
            m_energyTimer = 0f;
            GameManagerProp.instance.energy++;
            ShowEnergy(GameManagerProp.instance.energy);
        }
    }

    private void ShowEnergy(int settingValue)
    {
        txtEnergy.text = GameManagerProp.instance.energy.ToString("00") + "/100";
    }
    #endregion

}
