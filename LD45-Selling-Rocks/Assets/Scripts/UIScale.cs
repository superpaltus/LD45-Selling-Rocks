using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScale : MonoBehaviour
{
    [SerializeField]
    private Color m_activeColor;
    [SerializeField]
    private Color m_inactiveColor;
    [SerializeField]
    private Color m_nearTargetColor;
    [SerializeField]
    private Color m_onTargetColor;
    [SerializeField]
    private Color m_offTargetColor;

    enum UIScaleType
    {
        T,H,O,P
    }
    [SerializeField]
    private UIScaleType m_scaleType;

    [SerializeField] private GameObject[] m_blocks = new GameObject[20];

    private int targetValue;

    private void Start()
    {
        if (m_scaleType == UIScaleType.H) targetValue = UIScaleCalculator.WaterScale(GameManagerProp.instance.targetWater);
        else if (m_scaleType == UIScaleType.O) targetValue = UIScaleCalculator.OxygenScale(GameManagerProp.instance.targetOxygen);
        else if (m_scaleType == UIScaleType.T) targetValue = UIScaleCalculator.TemperatureScale(GameManagerProp.instance.targetTemperature);
        else if (m_scaleType == UIScaleType.P) targetValue = UIScaleCalculator.PressureScale(GameManagerProp.instance.targetPressure);
        print("target value for " + m_scaleType + " is: " + targetValue);
        GameObject[] m_blocksInvert = new GameObject[20];
        for(int i=0; i < 20; i++)
        {
            m_blocksInvert[i] = m_blocks[19 - i]; 
        }
        m_blocks = m_blocksInvert;
        m_blocks[targetValue].GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1f, 1f);
    }

    public void SetBlockValue(int settingValue)
    {
        if (settingValue >= 20)
        {
            print("setting value is more than 20");
            return;
        }

        Color newUIScaleColor;

        if (Mathf.Abs(settingValue - targetValue) <= 1)
        {
            m_blocks[targetValue].GetComponent<Image>().color = m_onTargetColor;
            newUIScaleColor = m_onTargetColor;
        }
        else if (Mathf.Abs(settingValue - targetValue) <= 3)
        {
            m_blocks[targetValue].GetComponent<Image>().color = m_nearTargetColor;
            newUIScaleColor = m_nearTargetColor;
        }
        else
        {
            m_blocks[targetValue].GetComponent<Image>().color = m_offTargetColor;
            newUIScaleColor = m_offTargetColor;
        }



        for (int j = 0; j < 20; j++)
        {
            int i = 19 - j;
            if (i == targetValue) continue;

            if (i < settingValue)
            {
                m_blocks[i].GetComponent<Image>().color = newUIScaleColor;
                //m_blocks[i].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
            else if (i == settingValue)
            {
                m_blocks[i].GetComponent<Image>().color = newUIScaleColor;
                //m_blocks[i].GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1f, 1f);
            }
            else
            {
                m_blocks[i].GetComponent<Image>().color = m_inactiveColor;
                //m_blocks[i].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }

        }


    }
}
