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

    private GameObject[] m_blocks = new GameObject[20];

    public void SetBlockValue(int settingValue)
    {
        if (settingValue >= 20)
        {
            print("setting value is more than 20");
            return;
        }

        for (int i = 0; i < 20; i++)
        {
            if (i < settingValue)
            {
                m_blocks[i].GetComponent<Image>().color = m_activeColor;
                m_blocks[i].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
            else if (i == settingValue)
            {
                m_blocks[i].GetComponent<Image>().color = m_activeColor;
                m_blocks[i].GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1f, 1f);
            }
            else
            {
                m_blocks[i].GetComponent<Image>().color = m_inactiveColor;
                m_blocks[i].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            }
        }


    }
}
